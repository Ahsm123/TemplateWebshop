using Webshop.API.DAL.Models;

namespace Webshop.Web.Services;

public class CategoryService
{
    private readonly HttpClient _client;

    public CategoryService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var response = await _client.GetAsync("https://localhost:7016/api/v1/Categories");
        if (response.IsSuccessStatusCode)
        {
            var categories = await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
            return categories!;
        }
        else
        {
            throw new Exception("Could not retrieve categories");
        }
    }
}
