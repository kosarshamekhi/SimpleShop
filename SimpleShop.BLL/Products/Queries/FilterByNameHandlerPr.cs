using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;
using SimpleShop.Model.Products.Queries;

namespace SimpleShop.BLL.Products.Queries;

public class FilterByNameHandlerPr : IRequestHandler<FilterByNamePr, ApplicationServiceResponse<Product>>
{
    private readonly ShopDbContext _shopDbContext;
    public FilterByNameHandlerPr(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<Product>>
        Handle(FilterByNamePr request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<Product> response = new();
        var products = _shopDbContext.Products.AsQueryable();
        if (!string.IsNullOrEmpty(request.ProductName))
        {
            products = products.Where(t => t.Description.Contains(request.ProductName));
        }
        var result = await products.Select(c => new Product
        {
            Id = c.Id,
            Description = c.Description,
            Quantity = c.Quantity
        }).ToListAsync();
        response.Result = result;
        return response;
    }
}
