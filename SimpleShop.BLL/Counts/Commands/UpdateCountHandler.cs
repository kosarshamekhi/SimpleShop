using SimpleShop.BLL.Framework;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.BLL.Counts.Commands;

public class UpdateCountHandler : BaseApplicationServiceHandler<UpdateCount, Count>
{
    public UpdateCountHandler(ShopDbContext shopDbContext) : base(shopDbContext)
    {
    }
    protected override async Task HandleRequest(UpdateCount request, CancellationToken cancellationToken)
    {
        Count count = _shopDbContext.Counts.SingleOrDefault(c => c.Id == request.Id);
        if (count == null)
        {
            AddError($"تگ با شناسه {request.Id} یافت نشد!");
        }
        else
        {
            count.Name = request.CountName;
            await _shopDbContext.SaveChangesAsync();
            AddResult(count);
        }
    }
}



