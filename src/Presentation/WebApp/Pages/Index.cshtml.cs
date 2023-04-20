using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IProductService _productService;

        public IReadOnlyCollection<ProductBrief> products = new List<ProductBrief>();
        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            products = (await _productService.GetAllProducts()).Items;
        }
    }
}