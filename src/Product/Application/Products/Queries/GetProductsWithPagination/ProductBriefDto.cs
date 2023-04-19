using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Products.Queries.GetProductsWithPagination;

public class ProductBriefDto : IMapFrom<Product>
{
    public Guid Id { get; init; }

    public string? Title { get; init; }

}
