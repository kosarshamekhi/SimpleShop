using MediatR;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Counts.Queries;

public class FilterByNameCo : IRequest<ApplicationServiceResponse<List<Count>>>
{
    public string? CountName { get; set; }
}
