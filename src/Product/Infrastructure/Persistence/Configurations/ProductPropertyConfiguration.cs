using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Configurations;

public class ProductPropertyConfiguration : IEntityTypeConfiguration<ProductProperty>
{
    public void Configure(EntityTypeBuilder<ProductProperty> builder)
    {
        builder.HasNoKey();
        //builder.HasOne(a => a.Product).WithOne();
        //builder.HasOne(a => a.Property).WithOne();


        builder.HasKey(sc => new { sc.ProductId, sc.PropertyId });

        builder
            .HasOne<Product>(sc => sc.Product)
            .WithMany(s => s.Properties)
            .HasForeignKey(sc => sc.PropertyId);


        builder
            .HasOne<Property>(sc => sc.Property)
            .WithMany(s => s.Products)
            .HasForeignKey(sc => sc.ProductId);
    }
}