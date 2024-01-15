
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
                    .ThenInclude(i => i.Uploads)
                .Include(p => p.Store)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(a => a.Municipality)
                    .ThenInclude(m => m.Province)
                .Include(p => p.Discount);
            #region Legacy
            /*.Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.Images.Uploads)
            .Include(p => p.Store)
            .Include(p => p.Store.Address)
            .Include(p => p.Store.Address.Municipality)
            .Include(p => p.Store.Address.Municipality.Province)
            .Include(p => p.Discount);*/
            #endregion
        }
    }
}
