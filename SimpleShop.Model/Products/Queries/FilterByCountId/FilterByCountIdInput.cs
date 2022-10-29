using MediatR;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Products.Queries.FilterByCountId;

public class FilterByCountIdInput : IRequest<ApplicationServiceResponse<List<FilterByCountIdOutput>>>
{
    public int? CountId { get; set; }
}
