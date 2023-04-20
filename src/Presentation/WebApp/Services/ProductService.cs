using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WebApp.Infrastructure;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService : IProductService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;

    private readonly string _remoteServiceBaseUrl;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;

        _remoteServiceBaseUrl = $"{_settings.Value.ProductUrl}/products";
    }
    public async Task<PaginatedList<ProductBrief>> GetAllProducts()
    {
        var uri = "https://localhost:7113/gw/productapi/products";// ApiUri.Product.GetAllProducts(_remoteServiceBaseUrl);

        var responseString = await _httpClient.GetStringAsync(uri);


        var products = JsonSerializer.Deserialize<PaginatedList<ProductBrief>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        return products;
    }
}
