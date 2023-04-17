using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(a => a.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Price)
            .IsRequired();

        builder.HasMany(a => a.Properties) ;
        builder.Property(y => y.Pictures)
       .HasConversion(
           from => string.Join(";", from),
           to => string.IsNullOrEmpty(to) ? new List<string>() : to.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList(),
           new ValueComparer<List<string>>(
               (c1, c2) => c1.SequenceEqual(c2),
               c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
               c => c.ToList()
       )
   );
    }
}