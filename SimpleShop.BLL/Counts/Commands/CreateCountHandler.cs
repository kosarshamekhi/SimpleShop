using MediatR;
using SimpleShop.BLL.Framework;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class CreateCountHandler : BaseApplicationServiceHandler<CreateCount, Count>
{
    public CreateCountHandler(ShopDbContext shopDbContext) : base(shopDbContext)
    {
    }
    protected override async Task HandleRequest(CreateCount request, CancellationToken cancellationToken)
    {
        Count count = new()
        {
            Name = request.CountName
        };
        await _shopDbContext.Counts.AddAsync(count);
        await _shopDbContext.SaveChangesAsync();
        AddResult(count);
    }
}