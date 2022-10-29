using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands.CreateCounts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands.CreateProducts;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class CreateProductAppService : IRequestHandler<CreateProductInput, ApplicationServiceResponse<CreateProductOutput>>
{
    private readonly ShopDbContext _shopDbContext;

    public CreateProductAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<CreateProductOutput>> Handle(CreateProductInput createProductInput, CancellationToken cancellationToken)
    {
        Product newProduct = new Product
        {
            Description = createProductInput.ProductName,
            Quantity = createProductInput.Quantity,
            CountId = createProductInput.CountId
        };
        await _shopDbContext.Products.AddAsync(newProduct);
        await _shopDbContext.SaveChangesAsync();

        return new ApplicationServiceResponse<CreateProductOutput>
        {
            Result = new CreateProductOutput() { ProductId = newProduct.Id }
        };
    }
}