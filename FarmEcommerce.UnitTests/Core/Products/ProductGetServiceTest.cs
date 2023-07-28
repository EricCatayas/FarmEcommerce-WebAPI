
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Services.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public class ProductGetServiceTest
    {
        private readonly IProductGetService _productGetService;
        private readonly Mock<IReadRepository<Product>> _mockProductRepo = new();

        public ProductGetServiceTest()
        {
            _productGetService = new ProductGetService(_mockProductRepo.Object);
        }
        [Fact]
        public void GetProduct_NonExistentId_ToThrowDataNotFoundException() 
        {
            int sample_Id = 32;

            _mockProductRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Product>>(), default)).ReturnsAsync(null as Product);

            Assert.ThrowsAsync<DataNotFoundException<Product>>(async () =>
            {
               await _productGetService.GetProduct(sample_Id);
            });
        }
        [Fact]
        public async void GetProduct_ValidArgument_ToReturnProduct()
        {
            var sample_category = new Product_Category()
            {
                Category_Name = "sample",
                Id = 13243,
            };
            var sample_store = new Store()
            {
                Name = "sample",
                Description = "sample",
                Established_Date = DateTime.Now,
                Images_Id = 43242,
            };
            var return_product = new Product()
            {
                Id = 4234,
                Name = "sample",
                Description = "sample",
                Price = 4234,
                Is_Negotiable = true,
                Per_Qty_Type = "sample",
                Qty_In_Stock = 4252,
                Store = sample_store,
                Store_Id = sample_store.Id,
                Category = sample_category,
                Category_Id = sample_category.Id
            };

            _mockProductRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Product>>(), default)).ReturnsAsync(return_product);

            var result_product = await _productGetService.GetProduct(return_product.Id);

            Assert.True(return_product.Name == result_product.Name &&
                        return_product.Description == result_product.Description &&
                        return_product.Is_Negotiable == result_product.Is_Negotiable &&
                        return_product.Price == result_product.Price &&
                        return_product.Qty_In_Stock == result_product.Qty_In_Stock &&
                        return_product.Category_Id == result_product.Category_Id);
        }
    }
}
