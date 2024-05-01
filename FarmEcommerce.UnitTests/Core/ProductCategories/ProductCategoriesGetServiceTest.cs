
using Bogus;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using FarmEcommerce.Core.Services.ProductCategories;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace FarmEcommerce.UnitTests.Core.ProductCategories
{
    public class ProductCategoriesGetServiceTest
    {
        private readonly IProductCategoriesGetService _productCategoriesGetService;
        private readonly Mock<IProductCategoriesGetRepository> _mockProductCategoriesGetRepository = new();
        private readonly Mock<IMemoryCache> _mockMemoryCache = new();
        public ProductCategoriesGetServiceTest()
        {
            _productCategoriesGetService = new ProductCategoriesGetService(_mockProductCategoriesGetRepository.Object);
        }
        [Fact]
        public async Task GetAllAsync_ToReturnEmptyProductCategoriesList()
        {
            // Arrange
            IEnumerable<Product_Category> emptyProductCategoriesList = new List<Product_Category>();
            _mockProductCategoriesGetRepository
                .Setup(x => x.GetListAsync())
                .ReturnsAsync(emptyProductCategoriesList);

            // Act
            IEnumerable<ProductCategoryDTO> result = await _productCategoriesGetService.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetProductCategories_ToReturnValidProductCategoryDTOs()
        {
            //Arrange
            var parent_Id = new Random().Next(12000);
            var numberOfSubCategories = new Random().Next(5);
            var productCategoriesList = GenerateParentProductCategoryWithSubCategories(parent_Id, numberOfSubCategories);

            _mockProductCategoriesGetRepository
                .Setup(x => x.GetListAsync())
                .ReturnsAsync(productCategoriesList);

            //Act
            var result = await _productCategoriesGetService.GetAllAsync();

            //Arrange
            Assert.True(result.FirstOrDefault(x => x.Id == parent_Id).SubCategories.Count() == numberOfSubCategories);
        }
        private IEnumerable<Product_Category> GenerateParentProductCategoryWithSubCategories(int parent_Id, int numberOfSubCategories = 2)
        {
            var _productCategoryFaker = new Faker<Product_Category>();

            var parent_category = _productCategoryFaker.Generate();
            parent_category.Id = parent_Id;

            var productCategories = new List<Product_Category>()
            {
                parent_category
            };

            _productCategoryFaker.RuleFor(x => x.Parent_Category_Id, parent_Id);

            if(numberOfSubCategories > 0)
            {
                var subCategories = _productCategoryFaker.GenerateBetween(numberOfSubCategories, numberOfSubCategories);
                productCategories.AddRange(subCategories);
            }

            return productCategories;
        }
    }
}
