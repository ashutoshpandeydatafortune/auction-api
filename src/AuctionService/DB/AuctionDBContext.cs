using Microsoft.EntityFrameworkCore;

namespace AuctionService.DB
{
    public class AuctionDBContext : DbContext
    {
        protected AuctionDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
