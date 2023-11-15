using Bogus;
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
    public class ProductCreateServiceTest : ProductServiceTest
    {
        private readonly IProductCreateService productCreateService;
        private readonly Mock<IRepository<Product>> _mockProductsRepo = new();
        private readonly Mock<IRepository<Images>> _mockImageRepo = new();
        private readonly Mock<IGetSignedInUserService> _mockGetSignedInUserService = new();
        public ProductCreateServiceTest() : base()
        {
            productCreateService = new ProductCreateService(_mockProductsRepo.Object, _mockImageRepo.Object, _mockGetSignedInUserService.Object);
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
                await productCreateService.AddAsync(sample_product);
            });
        }
        [Fact]
        public async void AddProduct_ValidArgument_ToReturnProductWithStoreIdAndImagesId()
        {
            var sample_category = _productCategoryFaker.Generate();
            var sample_Images = _imagesFaker.Generate();
            var sample_store = _storeFaker.Generate();
            var productCreateFaker = CreateProductCreateDTOFaker(sample_category);
            var sample_product = productCreateFaker.Generate();
            _appUserFaker.RuleFor(x => x.Store_Id, sample_store.Id);
            var appUser = _appUserFaker.Generate();

            var return_product = new Product()
            {
                Name = sample_product.Name,
                Description = sample_product.Description,
                Price = sample_product.Price,
                Is_Negotiable = sample_product.Is_Negotiable,
                Per_Qty_Type = sample_product.Per_Qty_Type,
                Qty_In_Stock = sample_product.Qty_In_Stock,
                Category = sample_category,
                Category_Id = sample_product.Category_Id,
                Store = sample_store,
                Images = sample_Images
            };

            _mockImageRepo.Setup(x => x.AddAsync(It.IsAny<Images>(), CancellationToken.None)).ReturnsAsync(sample_Images);
            _mockProductsRepo.Setup(x => x.AddAsync(It.IsAny<Product>(), default)).ReturnsAsync(return_product);
            _mockGetSignedInUserService.Setup(x => x.GetSignedInUser()).ReturnsAsync(appUser);

            var result_product = await productCreateService.AddAsync(sample_product);

            Assert.NotNull(result_product.GetImagesID());
            Assert.True(sample_product.Name == result_product.Name &&
                        sample_product.Description == result_product.Description &&
                        sample_product.Is_Negotiable == result_product.Is_Negotiable &&
                        sample_product.Price == result_product.Price &&
                        sample_product.Qty_In_Stock == result_product.Qty_In_Stock &&
                        sample_product.Category_Id == result_product.Category_Id &&
                        appUser.Store_Id == result_product.Store.Store_Id);

        }
        #endregion
        private Faker<ProductCreateDTO> CreateProductCreateDTOFaker(Product_Category sample_category)
        {
            return new Faker<ProductCreateDTO>()
                .RuleFor(x => x.Price, x => x.Finance.Amount(1, int.MaxValue))
                .RuleFor(x => x.Category_Id, sample_category.Id)
                .RuleFor(x => x.Name, x => x.Name.FullName())
                .RuleFor(x => x.Per_Qty_Type, x => x.Lorem.Sentence())
                .RuleFor(x => x.Description, x => x.Lorem.Sentence());
        }
    }
}