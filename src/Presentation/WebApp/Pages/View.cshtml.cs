using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class ViewModel : PageModel
    {
        public readonly IProductService _productService;
        public ProductBrief Product;
        public ViewModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGetAsync()
        {
            Guid id;
            Guid.TryParse(Request.RouteValues["id"].ToString(), out id);
            Product = (await _productService.GetAllProducts()).Items.FirstOrDefault(a=>a.Id == id);
        }
    }
}
