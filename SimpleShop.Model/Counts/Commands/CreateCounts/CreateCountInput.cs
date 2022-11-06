using MediatR;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Counts.Commands.CreateCounts;

public class CreateCountInput : IRequest<ApplicationServiceResponse<CreateCountOutput>>
{
    public string CountName { get; set; }
}
