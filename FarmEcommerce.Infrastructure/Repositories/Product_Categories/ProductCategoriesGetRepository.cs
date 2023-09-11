
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Infrastructure.Repositories.Product_Categories
{
    public class ProductCategoriesGetRepository : IProductCategoriesGetRepository
    {
        private readonly IReadRepository<Product_Category> _productCategoryRepo;

        public ProductCategoriesGetRepository(IReadRepository<Product_Category> productCategoryRepo) 
        {
            _productCategoryRepo = productCategoryRepo;
        }
        public async Task<IEnumerable<Product_Category>> GetListAsync()
        {
           return await _productCategoryRepo.ListAsync();
        }
    }
}