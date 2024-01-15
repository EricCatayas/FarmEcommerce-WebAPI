
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;

namespace FarmEcommerce.Core.Specifications.Products
{
    public sealed class ProductsPaginatedListSpecification : Specification<Product>
    {
        public ProductsPaginatedListSpecification(PaginationFilter filter)
        {
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            Query.IncludeAllEntities();
            Query.Skip(skip).Take(filter.PageSize);
        }
    }
}
