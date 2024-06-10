
using AuctionService.Entities;
using AuctionService.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.DB.Seeders
{
    public class DBInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            SeedData(scope.ServiceProvider.GetService<AuctionDBContext>());
        }

        private static void SeedData(AuctionDBContext? context)
        {
            if(context == null)
            {
                Console.WriteLine("Cannot run seed, context is null");
                return;
            }

            Console.WriteLine("Migrating database");
            try
            {
                context.Database.Migrate();
                Console.WriteLine("Database migrated");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot run migration: " + ex.Message);
                return;
            }

            if(context.Auctions.Any())
            {
                Console.WriteLine("Already have data - nothing to seed");
                return;
            }

            var auctions = new List<Auction>()
            {
                new Auction()
                {
                    Id = Guid.NewGuid(),
                    Status = Status.LIVE,
                    ReservePrice = 20000,
                    Seller = "Bob",
                    AuctionEnd = DateTime.UtcNow.AddDays(10),
                    Item = new Item()
                    {
                        Make = "Ford",
                        Model = "Fiesta Classic",
                        Color = "Smoke Grey",
                        Milleage = 43000,
                        Year = 2014,
                        ImageUrl = ""
                    }
                }
            };

            context.AddRange(auctions);
            context.SaveChanges();
        }
    }
}
