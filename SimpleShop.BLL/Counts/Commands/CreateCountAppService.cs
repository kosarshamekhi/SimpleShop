using MediatR;
using SimpleShop.DAL.Counts;
using SimpleShop.Model.Counts.Commands.CreateCounts;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Commands;

public class CreateCountAppService : IRequestHandler<CreateCountInput, ApplicationServiceResponse<CreateCountOutput>>
{
    private readonly EfCountRepository _efCountRepository;

    public CreateCountAppService(EfCountRepository efCountRepository)
    {
        _efCountRepository = efCountRepository;
    }
    public async Task<ApplicationServiceResponse<CreateCountOutput>> Handle(CreateCountInput createCountInput, CancellationToken cancellationToken)
    {
        var newCount = new Count
        {
            Name = createCountInput.CountName,
        };
        
        _efCountRepository.AddCount(newCount);

        return new ApplicationServiceResponse<CreateCountOutput>
        {
            Result = new CreateCountOutput() { CountId = newCount.Id }
        };
    }
}
