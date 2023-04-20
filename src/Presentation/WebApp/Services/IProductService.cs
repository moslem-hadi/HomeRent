using WebApp.ViewModels;

namespace WebApp.Services
{
    public interface IProductService
    {
        Task<PaginatedList<ProductBrief>> GetAllProducts();
    }
}
