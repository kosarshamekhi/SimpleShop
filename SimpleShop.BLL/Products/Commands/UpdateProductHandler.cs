using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class UpdateProductHandler : IRequestHandler<UpdateProduct, ApplicationServiceResponse<Product>>
{
    private readonly ShopDbContext _shopDbContext;

    public UpdateProductHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse<Product>>
        Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<Product> response = new();

        Product product = _shopDbContext.Products.SingleOrDefault(c => c.Id == request.Id);
        if (product == null)
        {
            response.AddError($"محصول با شناسه {request.Id} یافت نشد!");
        }
        else
        {
            product.Description = request.ProductName;
            product.Quantity = request.Quantity;
            product.CountId = request.CountId;

            await _shopDbContext.SaveChangesAsync();
            response.Result = product;
        }
        return response;
    }
}