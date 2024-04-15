using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Seeders
{
    public class DBInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("auctionsdb", MongoClientSettings.FromConnectionString(
                app.Configuration.GetConnectionString("DefaultConnectionString"))
            );

            await DB.Index<Item>()
                .Key(x => x.Make, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Color, KeyType.Text)
                .CreateAsync();
        }
    }
}
