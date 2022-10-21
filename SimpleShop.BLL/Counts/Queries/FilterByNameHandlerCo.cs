using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Counts.Queries;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Queries;

public class FilterByNameHandlerCo : IRequestHandler<FilterByNameCo, ApplicationServiceResponse<List<Count>>>
{
    private readonly ShopDbContext _shopDbContext;
    public FilterByNameHandlerCo(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<List<Count>>> Handle(FilterByNameCo request, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<List<Count>> response = new();
        var counts = _shopDbContext.Counts.AsQueryable();
        if (!string.IsNullOrEmpty(request.CountName))
        {
            counts = counts.Where(t => t.Name.Contains(request.CountName));
        }
        List<Count> result = await counts.Select(c => new Count
        {
            Id = c.Id,
            Name = c.Name,
        }).ToListAsync();

        response.Result = result;
        return response;
    }
}
