using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductCreateService
    {
        public Task<ProductDTO> AddAsync(ProductCreateDTO product);
    }
}
