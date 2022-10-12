using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class CreateCountHandler : IRequestHandler<CreateCount, ApplicationServiceResponse<Count>>
{
    private readonly ShopDbContext _shopDbContext;

    public CreateCountHandler(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<Count>> Handle(CreateCount request, CancellationToken cancellationToken)
    {
        Count count = new Count
        {
            Name = request.CountName,
        };
        await _shopDbContext.Counts.AddAsync(count);
        await _shopDbContext.SaveChangesAsync();

        return new ApplicationServiceResponse<Count>
        {
            Result = count
        };
    }
}