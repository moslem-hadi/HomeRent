using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product: BaseAuditableEntity
{
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public List<string> Pictures { get; set; } = new List<string>();

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public IList<ProductProperty> Properties{ get; set; }

}
public class ProductProperty
{
    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public Guid PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public virtual Property Property { get; set; }
}