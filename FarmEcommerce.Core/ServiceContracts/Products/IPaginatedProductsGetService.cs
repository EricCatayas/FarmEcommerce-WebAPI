
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IPaginatedProductsGetService
    {
        Task<IEnumerable<Product>> GetAsync(PaginationFilter filter);
    }
}
