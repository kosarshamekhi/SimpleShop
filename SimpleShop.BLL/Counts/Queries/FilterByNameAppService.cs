using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Counts.Queries.FilterByName;
using SimpleShop.Model.Framework;

namespace SimpleShop.BLL.Counts.Queries;

public class FilterByNameAppService : IRequestHandler<FilterByNameInput, ApplicationServiceResponse<List<FilterByNameOutput>>>
{
    private readonly ShopDbContext _shopDbContext;
    public FilterByNameAppService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<ApplicationServiceResponse<List<FilterByNameOutput>>> Handle(FilterByNameInput filterByNameInput, CancellationToken cancellationToken)
    {
        ApplicationServiceResponse<List<Count>> response = new();

        IQueryable<Count> counts = _shopDbContext.Counts.AsQueryable();
        if (!string.IsNullOrEmpty(filterByNameInput.CountName))
        {
            counts = counts.Where(t => t.Name.Contains(filterByNameInput.CountName));
        }
        List<FilterByNameOutput> result = await counts.Select(c => new FilterByNameOutput
        {
            CountId = c.Id,
            CountName = c.Name,
        }).ToListAsync();

        return new ApplicationServiceResponse<List<FilterByNameOutput>>
        {
            Result = new List<FilterByNameOutput>(result) { }
        };
    }
}
