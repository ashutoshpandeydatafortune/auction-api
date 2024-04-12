using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.DB
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Auction> Auctions { get; set; }
    }
}
