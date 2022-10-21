using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Commands;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.BLL.Products.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProduct, ApplicationServiceResponse>
{
    private readonly ShopDbContext _shopDbContext;

    public DeleteProductHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse response = new();

        Product product = _shopDbContext.Products.SingleOrDefault(c => c.Id == request.Id);
        if (product == null)
        {
            response.AddError($"محصول با شناسه {request.Id} یافت نشد");
        }
        else
        {
            _shopDbContext.Remove(_shopDbContext.Products.Single(a => a.Id == request.Id));
            await _shopDbContext.SaveChangesAsync();
        }
        return response;
    }
}



