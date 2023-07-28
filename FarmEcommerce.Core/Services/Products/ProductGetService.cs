
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Linq.Expressions;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductGetService : IProductGetService
    {
        private readonly IReadRepository<Product> _productsRepository;

        public ProductGetService(IReadRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> GetFilteredProducts(ProductsFilterDTO filterDTO)
        {
            var spec = new ProductsFilteredSpecification(filterDTO);
            var res = await _productsRepository.ListAsync(spec);

            return res;
        }

        public async Task<Product> GetProduct(int id)
        {
            var spec = new ProductSpecification(id);
            var res = await _productsRepository.GetBySpecAsync(spec);

            if (res == null)
                throw new DataNotFoundException<Product>(id);

            return res;
        }
    }
}
