using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands.UpdateProducts;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class UpdateProductAppService : IRequestHandler<UpdateProductInput, ApplicationServiceResponse<UpdateProductOutputt>>
{
    private readonly ShopDbContext _shopDbContext;

    public UpdateProductAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse<UpdateProductOutputt>> Handle(UpdateProductInput updateProductInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<Product> response = new();

        Product product = _shopDbContext.Products.SingleOrDefault(c => c.Id == updateProductInput.ProductId);
        if (product == null)
        {
            response.AddError($"محصول با شناسه {updateProductInput.ProductId} یافت نشد!");
        }
        else
        {
            product.Description = updateProductInput.ProductName;
            product.Quantity = updateProductInput.Quantity;
            product.CountId = updateProductInput.CountId;

            await _shopDbContext.SaveChangesAsync();
            response.Result = product;
        }
        return new ApplicationServiceResponse<UpdateProductOutputt>
        {
            Result = new UpdateProductOutputt() { ProductId = product.Id }
        };
    }
}