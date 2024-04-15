
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FarmEcommerce.Infrastructure.Repositories.Product_Categories
{
    public class ProductCategoriesGetRepository : IProductCategoriesGetRepository
    {
        private readonly IReadRepository<Product_Category> _productCategoryRepo;
        private readonly IMemoryCache _memoryCache;
        private const string _cacheKey = "Product_Categories_Data";

        public ProductCategoriesGetRepository(IReadRepository<Product_Category> productCategoryRepo, IMemoryCache memoryCache) 
        {
            _productCategoryRepo = productCategoryRepo;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<Product_Category>> GetListAsync()
        {
            IEnumerable<Product_Category>? product_Categories;
            bool alreadyExists = _memoryCache.TryGetValue(_cacheKey, out product_Categories);

            if (!alreadyExists)
            {
                product_Categories = await _productCategoryRepo.ListAsync();
                var cacheEntry = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(30));
                _memoryCache.Set(_cacheKey, product_Categories, cacheEntry);
            }

            return product_Categories; 
        }
    }
}