using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class UpdateCountHandler : IRequestHandler<UpdateCount, ApplicationServiceResponse<Count>>
{
    private readonly ShopDbContext _shopDbContext;

    public UpdateCountHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse<Count>> Handle(UpdateCount request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<Count> response = new();

        Count count = _shopDbContext.Counts.SingleOrDefault(c => c.Id == request.Id);
        if (count == null)
        {
            response.AddError($"شمارنده با شناسه {request.Id} یافت نشد!");
        }
        else
        {
            count.Name = request.CountName;

            await _shopDbContext.SaveChangesAsync();
            response.Result = count;
        }
        return response;
    }
}



