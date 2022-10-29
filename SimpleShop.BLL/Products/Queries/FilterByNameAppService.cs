using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;
using SimpleShop.Model.Products.Queries.FilterByName;

namespace SimpleShop.BLL.Products.Queries;

public class FilterByNameAppService : IRequestHandler<FilterByNameInput, ApplicationServiceResponse<List<FilterByNameOutput>>>
{
    private readonly ShopDbContext _shopDbContext;

    public FilterByNameAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<List<FilterByNameOutput>>> Handle(FilterByNameInput filterByNameInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<List<Product>> response = new();

        var products = _shopDbContext.Products.AsQueryable();
        if (!string.IsNullOrEmpty(filterByNameInput.ProductName))
        {
            products = products.Where(t => t.Description.Contains(filterByNameInput.ProductName));
        }
        List<FilterByNameOutput> result = await products.Select(c => new FilterByNameOutput
        {
            ProductId = c.Id,
            ProductName = c.Description,
        }).ToListAsync();

        return new ApplicationServiceResponse<List<FilterByNameOutput>>
        {
            Result = new List<FilterByNameOutput>(result) { }
        };
    }
}
