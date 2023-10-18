
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IPaginatedProductsGetService
    {
        Task<IEnumerable<ProductDTO>> GetAsync(PaginationFilter filter);
    }
}
