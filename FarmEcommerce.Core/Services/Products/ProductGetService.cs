
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductGetService : IProductGetService
    {
        private readonly IReadRepository<Product> _productRepo;

        public ProductGetService(IReadRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }        
        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var spec = new ProductSpecification(id);

                var result = await _productRepo.FirstOrDefaultAsync(spec);
                
                if (result == null)
                    throw new DataNotFoundException(typeof(Product), id);

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
