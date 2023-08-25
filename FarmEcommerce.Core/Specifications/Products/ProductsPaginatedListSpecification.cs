
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.Specifications.Products
{
    public sealed class ProductsPaginatedListSpecification : Specification<Product>
    {
        public ProductsPaginatedListSpecification(PaginationFilter filter)
        {
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            Query
               .Include(p => p.Category)
               .Include(p => p.Images)
               .Include(p => p.Store)
               .Include(p => p.Discount)
               .Skip(skip).Take(filter.PageSize);
        }
    }
    // Untested
    public sealed class ProductsFilteredPaginatedListSpecification : ProductsFilteredSpecification
    {
        public ProductsFilteredPaginatedListSpecification(ProductsFilterDTO filterDTO, PaginationFilter filter) : base(filterDTO)
        {
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            Query.Skip(skip).Take(filter.PageSize);
        }
    }
}
