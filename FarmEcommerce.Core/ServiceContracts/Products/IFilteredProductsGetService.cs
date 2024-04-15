using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IFilteredProductsGetService
    {
        public Task<IEnumerable<ProductDTO>> GetFilteredProducts(ProductsFilterDTO filterDTO);
    }
}
