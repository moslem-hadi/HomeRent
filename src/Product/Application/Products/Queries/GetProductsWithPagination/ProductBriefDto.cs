using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Products.Queries.GetProductsWithPagination;

public class ProductBriefDto : IMapFrom<Product>
{
    public Guid Id { get; init; }

    public string? Title { get; init; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public List<string> Pictures { get; set; } = new List<string>();

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

}
