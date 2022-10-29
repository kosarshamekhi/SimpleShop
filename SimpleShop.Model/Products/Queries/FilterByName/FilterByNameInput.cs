using MediatR;
using SimpleShop.Model.Framework;

namespace SimpleShop.Model.Products.Queries.FilterByName;

public class FilterByNameInput :IRequest<ApplicationServiceResponse<List<FilterByNameOutput>>>
{
    public string? ProductName { get; set; }
}
