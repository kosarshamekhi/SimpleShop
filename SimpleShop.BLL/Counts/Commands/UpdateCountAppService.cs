using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands.UpdateCounts;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class UpdateCountAppService : IRequestHandler<UpdateCountInput, ApplicationServiceResponse<UpdateCountOutput>>
{
    private readonly ShopDbContext _shopDbContext;

    public UpdateCountAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<ApplicationServiceResponse<UpdateCountOutput>> Handle(UpdateCountInput updateCountInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<Count> response = new();

        Count count = _shopDbContext.Counts.SingleOrDefault(c => c.Id == updateCountInput.CountId);
        if (count == null)
        {
            response.AddError($"شمارنده با شناسه {updateCountInput.CountId} یافت نشد!");
        }
        else
        {
            count.Name = updateCountInput.CountName;

            await _shopDbContext.SaveChangesAsync();
            response.Result = count;
        }
        return new ApplicationServiceResponse<UpdateCountOutput>
        {
            Result = new UpdateCountOutput() {CountId = count.Id}
        };
    }
}



