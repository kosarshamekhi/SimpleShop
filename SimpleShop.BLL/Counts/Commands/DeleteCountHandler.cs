using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.BLL.Counts.Commands;

public class DeleteCountHandler : IRequestHandler<DeleteCount, ApplicationServiceResponse>
{
    private readonly ShopDbContext _shopDbContext;

    public DeleteCountHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse> Handle(DeleteCount request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse response = new();

        Count count = _shopDbContext.Counts.SingleOrDefault(c=>c.Id == request.Id);
        if(count == null)
        {
            response.AddError($"شمارنده با شناسه {request.Id} یافت نشد");
        }
        else
        {
            _shopDbContext.Remove(_shopDbContext.Counts.Single(a => a.Id == request.Id));
            await _shopDbContext.SaveChangesAsync();
        }
        return response;
    }
}
