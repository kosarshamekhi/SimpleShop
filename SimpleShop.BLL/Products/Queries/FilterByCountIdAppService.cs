using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;
using SimpleShop.Model.Products.Queries.FilterByCountId;

namespace SimpleShop.BLL.Products.Queries;

public class FilterByCountIdAppService : IRequestHandler<FilterByCountIdInput, ApplicationServiceResponse<List<FilterByCountIdOutput>>>
{
    private readonly ShopDbContext _shopDbContext;

    public FilterByCountIdAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse<List<FilterByCountIdOutput>>> Handle(FilterByCountIdInput filterByCountIdInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<List<Product>> response = new();

        var products = _shopDbContext.Products.AsQueryable();
        if (filterByCountIdInput.CountId != null)
        {
            products = products.Where(products => products.CountId == filterByCountIdInput.CountId);
        }
        List<FilterByCountIdOutput> result = await products.Select(c => new FilterByCountIdOutput
        {
            ProductId = c.Id,
            ProductName = c.Description,
            Quantity = c.Quantity,
        }).ToListAsync();

        return new ApplicationServiceResponse<List<FilterByCountIdOutput>>
        {
            Result = new List<FilterByCountIdOutput>(result) { }
        };
    }
}
