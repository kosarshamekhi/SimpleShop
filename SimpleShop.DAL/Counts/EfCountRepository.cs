using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.DAL.Counts;

public class EfCountRepository : ICountRepository
{
    private readonly ShopDbContext _shopDbContext;

    public EfCountRepository(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public void AddCount(Count count)
    {
        _shopDbContext.Counts.AddAsync(count);
        _shopDbContext.SaveChangesAsync();
    }
}

