using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.DAL.Products;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.Quantity).IsRequired();
    }
}
