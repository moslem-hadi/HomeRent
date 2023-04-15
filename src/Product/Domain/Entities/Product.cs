using Domain.Common;

namespace Domain.Entities;

public class Product: BaseAuditableEntity
{
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public List<string> Pictures { get; set; } = new List<string>();

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public List<Property> Properties{ get; set; } = new List<Property>();

}