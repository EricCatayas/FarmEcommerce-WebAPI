using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Images;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Services.Products;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public class ProductCreateServiceTest
    {
        private readonly IProductCreateService productCreateService;
        private readonly Mock<IRepository<Product>> _mockProductsRepo = new();
        private readonly Mock<IImageCreateRepository> _mockImageCreateRepo = new();
        private readonly Mock<IGetSignedInUserService> _mockGetSignedInUserService = new();
        public ProductCreateServiceTest()
        {
            productCreateService = new ProductCreateService(_mockProductsRepo.Object, _mockGetSignedInUserService.Object, _mockImageCreateRepo.Object);
        }
        #region AddProduct
        [Fact]
        public void AddProduct_InvalidArgument_ToThrowArgumentException()
        {
            var sample_product = new ProductCreateDTO()
            {
                Name = null,
                Description = "Sample",
                Price = 0,
                Is_Negotiable = true,
                Per_Qty_Type = "Sample",
                Qty_In_Stock = 0,
                Category_Id = 13424,
            };
            Assert.ThrowsAsync<ArgumentException>( async () =>
            {
                await productCreateService.AddProduct(sample_product);
            });
        }
        [Fact]
        public async void AddProduct_ValidArgument_ToReturnProductWithStoreIdAndImagesId()
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
            var sample_product = new ProductCreateDTO()
            {
                Name = "sample",
                Description = "sample",
                Price = 23412,
                Is_Negotiable = true,
                Per_Qty_Type = "sample",
                Qty_In_Stock = 242,       
                Category_Id = sample_category.Id,
            };

            var return_product = new Product()
            {
                Name = sample_product.Name,
                Description = sample_product.Description,
                Price = sample_product.Price,
                Is_Negotiable = sample_product.Is_Negotiable,
                Per_Qty_Type = sample_product.Per_Qty_Type,
                Qty_In_Stock = sample_product.Qty_In_Stock,
                Category = sample_category,
                Category_Id = sample_product.Category_Id
            };

            var appUser = new ApplicationUser()
            {
                UserName = "sample",
                Email = "sample",
                Contact_Num1 = "12341243",
                Contact_Num2 = "12341234",
                Store_Id = sample_store.Id,
            };

            _mockImageCreateRepo.Setup(x => x.GetImageId()).ReturnsAsync(1431);
            _mockProductsRepo.Setup(x => x.AddAsync(It.IsAny<Product>(), default)).ReturnsAsync(return_product);
            _mockGetSignedInUserService.Setup(x => x.GetSignedInUser()).ReturnsAsync(appUser);

            var result_product = await productCreateService.AddProduct(sample_product);

            Assert.NotNull(result_product.Images_Id);
            Assert.NotNull(result_product.Store_Id);
            Assert.True(sample_product.Name == result_product.Name &&
                        sample_product.Description == result_product.Description &&
                        sample_product.Is_Negotiable == result_product.Is_Negotiable &&
                        sample_product.Price == result_product.Price &&
                        sample_product.Qty_In_Stock == result_product.Qty_In_Stock &&
                        sample_product.Category_Id == result_product.Category_Id &&
                        appUser.Store_Id == result_product.Store_Id);

        }
        #endregion
    }
}