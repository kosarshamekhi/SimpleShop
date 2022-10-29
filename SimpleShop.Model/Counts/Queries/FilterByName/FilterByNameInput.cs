using MediatR;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Counts.Queries.FilterByName;

public class FilterByNameInput : IRequest<ApplicationServiceResponse<List<FilterByNameOutput>>>
{
    public string? CountName { get; set; }
}
