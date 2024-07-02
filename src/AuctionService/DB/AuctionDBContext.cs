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
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .HasOne(a => a.Item)
                .WithOne(i => i.Auction)
                .HasForeignKey<Item>(i => i.AuctionId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
