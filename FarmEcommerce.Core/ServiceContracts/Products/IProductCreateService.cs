using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductCreateService
    {
        public Task<Product> AddProduct(ProductCreateDTO product);
    }
}
