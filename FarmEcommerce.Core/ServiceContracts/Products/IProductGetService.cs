using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductGetService
    {
        public Task<ProductDTO> GetProduct(int product_id);        
    }
}
