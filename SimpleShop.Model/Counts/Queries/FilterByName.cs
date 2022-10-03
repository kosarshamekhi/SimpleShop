using MediatR;
using SimpleShop.Model.Counts.Dtos;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Counts.Queries;

public class FilterByName:IRequest<ApplicationServiceResponse<List<CountQr>>>
{
    public string? CountName { get; set; }
}