
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
    public class ProductGetServiceTest
    {
        private readonly IProductGetService _productGetService;
        private readonly Mock<IReadRepository<Product>> _mockProductRepo = new();
        private readonly Faker<Product_Category> _productCategoryFaker;
        private readonly Faker<Store> _storeFaker;
        private readonly Faker<Product> _productFaker;

        public ProductGetServiceTest()
        {
            _productGetService = new ProductGetService(_mockProductRepo.Object);
            #region ProductFaker
            _productFaker = new Faker<Product>()
                .RuleFor(x => x.Price, x => x.Finance.Amount(0, int.MaxValue));
            _productCategoryFaker = new Faker<Product_Category>()
                .RuleFor(x => x.Category_Name, x => x.Name.Random.ToString());
            _storeFaker = new Faker<Store>()
                .RuleFor(x => x.Established_Date, x => x.Date.Soon(0))
                .RuleFor(x => x.Description, x => x.Lorem.Word());
            #endregion
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

            _productFaker.RuleFor(x => x.Category, sample_category);
            _productFaker.RuleFor(x => x.Category_Id, sample_category.Id);
            _productFaker.RuleFor(x => x.Store, sample_store);
            _productFaker.RuleFor(x => x.Store_Id, sample_store.Id);
            var return_product = _productFaker.Generate();
           

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
