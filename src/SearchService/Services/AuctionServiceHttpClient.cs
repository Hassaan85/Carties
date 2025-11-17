using System.Drawing;
using MongoDB.Entities;

namespace SearchService.Services;


public class AuctionSerivceHttpClient
{
private readonly IConfiguration _config;
private readonly HttpClient _httpClient;
public  AuctionSerivceHttpClient(HttpClient httpClient, IConfiguration config)
{
    _httpClient = httpClient;
    _config = config;
}

public async Task<List<Item>>GetItemsForSearch()
    {
        var lastUpdated = await DB.Find<Item , string>()
        .Sort(x => x.Descending(x => x.UpdatedAt))
        .Project(x => x.UpdatedAt.ToString())
        .ExecuteFirstAsync();

        return await _httpClient.GetFromJsonAsync<List<Item>>
        (_config["AuctionServiceUrl"] + "/api/auctions?date=" + lastUpdated);
    }

}