
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FarmEcommerce.Core.Services.ProductCategories
{
    public class ProductCategoriesGetService : IProductCategoriesGetService
    {
        private readonly IProductCategoriesGetRepository _productCategoriesGetRepository;
        private readonly IMemoryCache _memoryCache;

        public ProductCategoriesGetService(IProductCategoriesGetRepository productCategoriesGetRepository, IMemoryCache memoryCache)
        {
            _productCategoriesGetRepository = productCategoriesGetRepository;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<ProductCategoryDTO>> GetAllAsync()
        {
            //TODO Caching

            var product_Categories = await _productCategoriesGetRepository.GetListAsync();

            var productCategoryDTOs = new List<ProductCategoryDTO>();
                
            productCategoryDTOs.AddRange(product_Categories.Where(cat => cat.Parent_Category_Id == null).Select(cat => new ProductCategoryDTO
            {
                Id = cat.Id,
                Name = cat.Category_Name,
                Image_Url = cat.Image_Url
            }));

            foreach(var productCategoryDTO in productCategoryDTOs)
            {
                productCategoryDTO.SubCategories = product_Categories.Where(cat => cat.Parent_Category_Id != null && cat.Parent_Category_Id == productCategoryDTO.Id).Select(cat => new ProductCategoryDTO
                {
                    Id = cat.Id,
                    Name = cat.Category_Name,
                    Image_Url = cat.Image_Url
                });
            }
                
            return productCategoryDTOs;
        }
    }
}
