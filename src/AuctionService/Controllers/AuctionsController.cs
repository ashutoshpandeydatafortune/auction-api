using AuctionService.DB;
using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;
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

        public AuctionsController(AuctionDBContext context, IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDTO>>> GetAllAuctions()
        {
            var auctions = await _context.Auctions
                .Include(x => x.Item)
                .OrderBy(x => x.Item.Make)
                .ToListAsync();

            return _mapper.Map<List<AuctionDTO>>(auctions);
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

        [HttpPost]
        public async Task<ActionResult> CreateAuction(AuctionDTO auctionDTO)
        {
            var auction = _mapper.Map<Auction>(auctionDTO);

            _context.Auctions.Add(auction);

            var created = await _context.SaveChangesAsync() > 0;

            if (!created) return BadRequest("Invalid request, cannot save to database");

            return CreatedAtAction(nameof(GetAuctionById), new {auction.Id}, _mapper.Map<AuctionDTO>(auction));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDTO auctionDTO)
        {
            var auction = await _context.Auctions.Include(x => x.Item)
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (auction == null) return NotFound();

            auction.Item.Make = auctionDTO.Make ?? auction.Item.Make;
            auction.Item.Year = auctionDTO.Year ?? auction.Item.Year;
            auction.Item.Model = auctionDTO.Model ?? auction.Item.Model;
            auction.Item.Color = auctionDTO.Color ?? auction.Item.Color;
            auction.Item.Milleage = auctionDTO.Milleage ?? auction.Item.Milleage;

            var updated = await _context.SaveChangesAsync() > 0;

            if (!updated) return BadRequest("Invalid request, cannot save to database");

            return CreatedAtAction(nameof(GetAuctionById), new { auction.Id }, _mapper.Map<AuctionDTO>(auction));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuctionDTO>> DeleteAuctionById(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null) return NotFound();

            _context.Auctions.Remove(auction);

            var deleted = await _context.SaveChangesAsync() > 0;

            if (!deleted) return BadRequest("Invalid id, cannot be removed");

            return Ok();
        }
    }
}
