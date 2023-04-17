using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ProductProperty
{
    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public Guid PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public virtual Property Property { get; set; }
}