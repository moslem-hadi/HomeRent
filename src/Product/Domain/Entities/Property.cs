using Domain.Common;

namespace Domain.Entities;

public class Property : BaseEntity
{
    public string Title{ get; set; }
    public string Icon { get; set; }

    public IList<ProductProperty> Products { get; set; }

}