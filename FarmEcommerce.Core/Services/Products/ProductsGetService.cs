
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductsGetService : IProductsGetService
    {
        private readonly IReadRepository<Product> _productRepo;

        public ProductsGetService(IReadRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<Product>> GetFilteredProducts(ProductsFilterDTO filterDTO)
        {
            var spec = new ProductsFilteredSpecification(filterDTO);
            var result = await _productRepo.ListAsync(spec);
            return result;
        }
    }
}
