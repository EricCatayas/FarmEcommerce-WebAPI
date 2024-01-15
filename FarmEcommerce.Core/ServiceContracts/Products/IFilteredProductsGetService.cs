
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IFilteredProductsGetService
    {
        public Task<IEnumerable<Product>> GetFilteredProducts(ProductsFilterDTO filterDTO);
    }
}
