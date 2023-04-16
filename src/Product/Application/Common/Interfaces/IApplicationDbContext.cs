using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product>  Products { get; }
    DbSet<Property> Properties { get; }
    DbSet<ProductProperty> ProductProperties { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}