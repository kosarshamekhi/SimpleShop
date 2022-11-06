using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.DAL.Counts;

public interface ICountRepository
{
    void AddCount(Count count);
}
