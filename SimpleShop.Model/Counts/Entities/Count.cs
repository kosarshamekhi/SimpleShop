using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.Model.Counts.Entities;

public class Count : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
