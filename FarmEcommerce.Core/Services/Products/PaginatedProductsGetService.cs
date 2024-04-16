using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class PaginatedProductsGetService : IPaginatedProductsGetService
    {
        private readonly IReadRepository<Product> _productRepo;
        public PaginatedProductsGetService(IReadRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<ProductDTO>> GetAsync(PaginationFilter filter)
        {
            if (filter.PageNumber < 1)
                throw new ArgumentException("Page number must not be 0 or below");
            if (filter.PageSize < 1)
                throw new ArgumentException("Page size must not be 0 or below");

            var specification = new ProductsPaginatedListSpecification(filter);
            var result = await _productRepo.ListAsync(specification);            

            return result.Select(x => new ProductDTO(x));
        }
    }
}
