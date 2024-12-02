using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Entities;

namespace SearchService.Models;

public static class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));
        await DB.Index<Item>()
            .Key(x => x.Make, KeyType.Text)
            .Key(x => x.Model, KeyType.Text)
            .Key(x => x.Color, KeyType.Text)
            .CreateAsync();
        var count = await DB.CountAsync<Item>();
        if(count > 0)
            return;
        else
        {
            var jsonItems = await File.ReadAllTextAsync("data/Auctions.json");
            var items = JsonSerializer.Deserialize<List<Item>>(jsonItems,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            await DB.SaveAsync(items);
        }
    }
}