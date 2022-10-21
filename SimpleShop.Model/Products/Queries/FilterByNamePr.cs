using MediatR;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;

namespace SimpleShop.Model.Products.Queries;

public class FilterByNamePr: IRequest<ApplicationServiceResponse<List<Product>>>
{
    public string? ProductName { get; set; }
}
