using SimpleShop.Model.Framework;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.Model.Products.Entities;

public class Product : BaseEntity
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public Count Count { get; set; }
    public int CountId { get; set; }
}
