using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(50);
         

        builder.Property(a => a.Icon)
            .IsRequired()
            .HasMaxLength(50);

        //builder.HasMany(e => e.Products);
    }
}