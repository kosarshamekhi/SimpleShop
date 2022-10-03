using Microsoft.EntityFrameworkCore;
using SimpleShop.BLL.Framework;
using SimpleShop.DAL.Counts;
using SimpleShop.DAL.DbContexts;
using SimpleShop.Model.Counts.Dtos;
using SimpleShop.Model.Counts.Queries;
using System.Diagnostics;

namespace SimpleShop.BLL.Counts.Queries;

public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<CountQr>>
{
    public FilterByNameHandler(ShopDbContext shopDbContext) : base(shopDbContext)
    {

    }

    protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
    {
        var result = await _shopDbContext.Counts.WhereOver(request.CountName).ToCountQrAsync();
        AddResult(result);
    }
}
