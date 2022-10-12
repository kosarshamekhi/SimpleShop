using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProduct, ApplicationServiceResponse<Product>>
{
    private readonly ShopDbContext _shopDbContext;

    public CreateProductHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<Product>>
        Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        Product product = new Product
        {
            Description = request.ProductName,
            Quantity = request.Quantity,
            CountId = request.CountId
        };
        await _shopDbContext.Products.AddAsync(product);
        await _shopDbContext.SaveChangesAsync();

        return new ApplicationServiceResponse<Product>
        {
            Result = product
        };
    }
}