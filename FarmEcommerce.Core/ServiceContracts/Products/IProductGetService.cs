using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    /// <exception>
    /// Throws <see cref="DataNotFoundException"/> if product does with corresponding Id does not exist in the database.
    /// </exception>
    public interface IProductGetService
    {
        public Task<ProductDTO> GetProduct(int product_id);        
    }
}
