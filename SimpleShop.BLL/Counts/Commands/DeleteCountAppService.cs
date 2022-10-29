using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Counts.Commands.DeleteCounts;

namespace SimpleShop.BLL.Counts.Commands;

public class DeleteCountAppService : IRequestHandler<DeleteCountInput, ApplicationServiceResponse>
{
    private readonly ShopDbContext _shopDbContext;

    public DeleteCountAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse> Handle(DeleteCountInput deleteCountInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse response = new();

        Count count = _shopDbContext.Counts.SingleOrDefault(c=>c.Id == deleteCountInput.CountId);
        if(count == null)
        {
            response.AddError($"شمارنده با شناسه {deleteCountInput.CountId} یافت نشد");
        }
        else
        {
            _shopDbContext.Remove(_shopDbContext.Counts.Single(a => a.Id == deleteCountInput.CountId));
            await _shopDbContext.SaveChangesAsync();
        }
        return response;
    }
}
