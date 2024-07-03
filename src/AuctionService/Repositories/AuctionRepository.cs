using AuctionService.DB;
using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDBContext _context;

        public AuctionRepository(AuctionDBContext context)
        {
            _context = context;
        }

        public async Task<Auction> GetAuctionByIdAsync(Guid id)
        {
            return await _context.Auctions.Include(a => a.Item).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
        {
            return await _context.Auctions.Include(a => a.Item).ToListAsync();
        }

        public async Task AddAuctionAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuctionAsync(Auction auction)
        {
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuctionAsync(Guid id)
        {
            var auction = await GetAuctionByIdAsync(id);
            if (auction != null)
            {
                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
