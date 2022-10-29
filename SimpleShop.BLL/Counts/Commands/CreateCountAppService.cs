using MediatR;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Commands.CreateCounts;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class CreateCountAppService : IRequestHandler<CreateCountInput, ApplicationServiceResponse<CreateCountOutput>>
{
    private readonly ShopDbContext _shopDbContext;

    public CreateCountAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<CreateCountOutput>> Handle(CreateCountInput createCountInput, CancellationToken cancellationToken)
    {
        var newCount = new Count
        {
            Name = createCountInput.CountName,
        };
        await _shopDbContext.Counts.AddAsync(newCount);
        await _shopDbContext.SaveChangesAsync();

        return new ApplicationServiceResponse<CreateCountOutput>
        {
            Result = new CreateCountOutput() { CountId = newCount.Id }
        };
    }
}
