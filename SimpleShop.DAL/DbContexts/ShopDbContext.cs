using Microsoft.EntityFrameworkCore;
using SimpleShop.Model.Products.Entities;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.DAL.DbContexts;

public class ShopDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Count> Counts { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        foreach (var item in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
        }
    }
}
