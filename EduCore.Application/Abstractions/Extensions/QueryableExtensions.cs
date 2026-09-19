using EduCore.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Abstractions.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<GetAllDataResponse<TResponse>>ToPagedResponseAsync<TEntity,TResponse>(
            this IQueryable<TEntity> query,
            int pageNumber,
            int pageSize,
            Func<TEntity, TResponse> mapper)
        {
            var totalDataCount = await query.CountAsync();
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new GetAllDataResponse<TResponse>
            {
                PageNumber = pageNumber,
                TotalPage = (int)Math.Ceiling(totalDataCount / (double)pageSize),
                TotalDateCount = totalDataCount,
                Data = data.Select(mapper).ToList()
            };
        }
    }
}
