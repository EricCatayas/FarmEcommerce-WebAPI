
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmEcommerce.Core.Common.Extentions
{
    public static class IQueryableProductExtention
    {
        public static IQueryable<Product> IncludeAllEntities(this IQueryable<Product> query)
        {
            query = query
                .Include(p => p.Category)
                .Include(p => p.Images)
                    .ThenInclude(i => i.Uploads)
                .Include(p => p.Store)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(a => a.Municipality)
                    .ThenInclude(m => m.Province)
                .Include(p => p.Discount);

            return query;
        }
    }
}
