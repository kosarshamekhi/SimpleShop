using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.DAL.Counts;

public class CountConfig : IEntityTypeConfiguration<Count>
{
    public void Configure(EntityTypeBuilder<Count> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
    }
}
