using WebApp.ViewModels;

namespace WebApp.Services
{
    public interface IProductService
    {
        Task<PaginatedList<ProductBrief>> GetAllProducts(CancellationToken cancellationToken = default);
        Task<ProductBrief?> GetProductById(Guid Id, CancellationToken cancellationToken = default);
    }
}
