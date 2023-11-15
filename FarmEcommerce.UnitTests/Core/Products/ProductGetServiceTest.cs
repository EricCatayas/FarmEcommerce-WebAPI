
using Ardalis.Specification;
using Bogus;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Services.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public class ProductGetServiceTest : ProductServiceTest
    {
        private readonly IProductGetService _productGetService;
        private readonly Mock<IReadRepository<Product>> _mockProductRepo = new();

        public ProductGetServiceTest() : base()
        {
            _productGetService = new ProductGetService(_mockProductRepo.Object);            
        }
        [Fact]
        public void GetProduct_NonExistentId_ToThrowDataNotFoundException() 
        {
            int sample_Id = new Random().Next(12000);

            _mockProductRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Product>>(), default)).ReturnsAsync(null as Product);

            Assert.ThrowsAsync<DataNotFoundException>(async () =>
            {
               await _productGetService.GetProduct(sample_Id);
            });
        }

        [Fact]
        public async void GetProduct_ValidArgument_ToReturnProduct()
        {
            var sample_category = _productCategoryFaker.Generate();
            var sample_store = _storeFaker.Generate();
            var sample_images = _imagesFaker.Generate();

            _productFaker.RuleFor(x => x.Category, sample_category);
            _productFaker.RuleFor(x => x.Category_Id, sample_category.Id);
            _productFaker.RuleFor(x => x.Store, sample_store);
            _productFaker.RuleFor(x => x.Store_Id, sample_store.Id);
            _productFaker.RuleFor(x => x.Images, sample_images);
            _productFaker.RuleFor(x => x.Images_Id, sample_images.Id);
            var return_product = _productFaker.Generate();
           

            _mockProductRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Product>>(), default)).ReturnsAsync(return_product);

            var result_product = await _productGetService.GetProduct(return_product.Id);


            Assert.NotNull(result_product);
            Assert.True(return_product.Name == result_product.Name &&
                        return_product.Description == result_product.Description &&
                        return_product.Is_Negotiable == result_product.Is_Negotiable &&
                        return_product.Price == result_product.Price &&
                        return_product.Qty_In_Stock == result_product.Qty_In_Stock &&
                        return_product.Category_Id == result_product.Category_Id);
        }
    }
}
