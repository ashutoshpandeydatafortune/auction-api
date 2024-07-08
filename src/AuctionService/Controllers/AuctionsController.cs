using AuctionService.DB;
using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/auctions")]
    public class AuctionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AuctionDBContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuctionsController(AuctionDBContext context, IMapper mapper, IPublishEndpoint publishEndpoint) 
        {
            _mapper = mapper;
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDTO>>> GetAllAuctions(string date)
        {
            var query = _context.Auctions.OrderBy(x => x.Item.Make).AsQueryable();

            if(!string.IsNullOrEmpty(date))
            {
                query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
            }

            return await query.ProjectTo<AuctionDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDTO>> GetAuctionById(Guid id)
        {
            var auction = await _context.Auctions
                .Include(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (auction == null) return NotFound();

            return _mapper.Map<AuctionDTO>(auction);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateAuction(AuctionDTO auctionDTO)
        {
            var auction = _mapper.Map<Auction>(auctionDTO);

            auction.Seller = User.Identity.Name;

            _context.Auctions.Add(auction);

            var created = await _context.SaveChangesAsync() > 0;

            if (!created) return BadRequest("Invalid request, cannot save to database");

            var newAuction = _mapper.Map<AuctionDTO>(auction);

            await _publishEndpoint.Publish(_mapper.Map<AuctionCreated>(newAuction));

            return CreatedAtAction(nameof(GetAuctionById), new { auction.Id }, _mapper.Map<AuctionDTO>(auction));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDTO auctionDTO)
        {
            var auction = await _context.Auctions.Include(x => x.Item)
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (auction == null) return NotFound();

            if (auction.Seller != User.Identity.Name) return Forbid();

            auction.Item.Make = auctionDTO.Make ?? auction.Item.Make;
            auction.Item.Year = auctionDTO.Year ?? auction.Item.Year;
            auction.Item.Model = auctionDTO.Model ?? auction.Item.Model;
            auction.Item.Color = auctionDTO.Color ?? auction.Item.Color;
            auction.Item.Mileage = auctionDTO.Mileage ?? auction.Item.Mileage;

            var updated = await _context.SaveChangesAsync() > 0;

            if (!updated) return BadRequest("Invalid request, cannot save to database");

            await _publishEndpoint.Publish(_mapper.Map<AuctionUpdated>(auction));

            return CreatedAtAction(nameof(GetAuctionById), new { auction.Id }, _mapper.Map<AuctionDTO>(auction));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuctionDTO>> DeleteAuctionById(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null) return NotFound();

            if (auction.Seller != User.Identity.Name) return Forbid();

            _context.Auctions.Remove(auction);

            var deleted = await _context.SaveChangesAsync() > 0;

            if (!deleted) return BadRequest("Invalid id, cannot be removed");

            await _publishEndpoint.Publish(_mapper.Map<AuctionDeleted>(auction));

            return Ok();
        }
    }
}
