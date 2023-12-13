
using Ardalis.Specification;
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.Common.Extentions
{
    public static class ProductSpecificationBuilderExtention
    {
        public static void IncludeAllEntities(this ISpecificationBuilder<Product> query)
        {
            query
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Store)
                .Include(p => p.Store.Address)
                .Include(p => p.Store.Address.Municipality)
                .Include(p => p.Store.Address.Municipality.Province)
                .Include(p => p.Discount);
        }
    }
}
