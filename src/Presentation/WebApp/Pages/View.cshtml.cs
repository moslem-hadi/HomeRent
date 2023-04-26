using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class ViewModel : PageModel
    {
        public readonly IProductService _productService;
        public ProductBrief? Product;
        public ViewModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Guid.TryParse(Request.RouteValues["id"]!.ToString(), out Guid id);
            Product = await _productService.GetProductById(id);
            if (Product is null)
                return RedirectToPage("Index");
            return Page();
        }
    }
}
