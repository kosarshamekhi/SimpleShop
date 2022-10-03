using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Model.Counts.Dtos;
using SimpleShop.Model.Counts.Entities;

namespace SimpleShop.DAL.Counts;

public static class CountQueryExtensions
{
    public static IQueryable<Count> WhereOver(this IQueryable<Count> counts, string tagName)
    {
        if (!string.IsNullOrEmpty(tagName))
            counts = counts.Where(t => t.Name.Contains(tagName));
        return counts;
    }
    public static List<CountQr> ToCountQr(this IQueryable<Count> counts)
    {
        return counts.Select(counts => new CountQr
        {
            Id = counts.Id,
            CountName = counts.Name,
        }).ToList();
    }

    public static async Task<List<CountQr>> ToCountQrAsync(this IQueryable<Count> counts)
    {
        return await counts.Select(counts => new CountQr
        {
            Id = counts.Id,
            CountName = counts.Name,
        }).ToListAsync();
    }
}
