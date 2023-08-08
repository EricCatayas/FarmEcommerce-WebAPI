
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductsGetService
    {
        public Task<IEnumerable<Product>> GetFilteredProducts(ProductsFilterDTO filterDTO);
    }
}
