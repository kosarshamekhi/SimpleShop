using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands.DeleteProducts;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class DeleteProductAppService : IRequestHandler<DeleteProductInput, ApplicationServiceResponse>
{
    private readonly ShopDbContext _shopDbContext;

    public DeleteProductAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse> Handle(DeleteProductInput deleteProductInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse response = new();

        Product product = _shopDbContext.Products.SingleOrDefault(c => c.Id == deleteProductInput.ProductId);
        if (product == null)
        {
            response.AddError($"محصول با شناسه {deleteProductInput.ProductId} یافت نشد");
        }
        else
        {
            _shopDbContext.Remove(_shopDbContext.Products.Single(a => a.Id == deleteProductInput.ProductId));
            await _shopDbContext.SaveChangesAsync();
        }
        return response;
    }
}



