using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using System.Text.Json;

namespace SearchService.Seeders
{
    public class DBInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("auctionsdb", MongoClientSettings.FromConnectionString(
                app.Configuration.GetConnectionString("DefaultConnection"))
            );

            await DB.Index<Item>()
                .Key(x => x.Make, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Color, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Item>();
            if (count == 0)
            {
                Console.WriteLine("Seeding data");

                var itemData = await File.ReadAllTextAsync("Data/auctions.json");
                if (itemData != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

                    if (items != null)
                    {
                        await DB.SaveAsync(items);
                    }
                }
            }

            Console.WriteLine("Search data setup done");
        }
    }
}
