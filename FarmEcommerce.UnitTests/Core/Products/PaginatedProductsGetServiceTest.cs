
using Bogus;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Services.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;

namespace FarmEcommerce.UnitTests.Core.Products
{
    public class PaginatedProductsGetServiceTest : ProductServiceTest
    {
        private readonly IPaginatedProductsGetService _paginatedProductsGetService;
        private readonly Mock<IReadRepository<Product>> _mockProductRepo = new();
        public PaginatedProductsGetServiceTest() : base()
        {
            _paginatedProductsGetService = new PaginatedProductsGetService(_mockProductRepo.Object);
        }
        [Fact]
        public void GetAsync_PageNumberLessThanOne_ToThrowArgumentException()
        {
            var filter = GeneratePaginationFilter(0, 10);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _paginatedProductsGetService.GetAsync(filter);
            });


        }
        [Fact]
        public void GetAsync_PageSizeLessThanOne_ToThrowArgumentException()
        {
            var filter = GeneratePaginationFilter(10, 0);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _paginatedProductsGetService.GetAsync(filter);
            });
        }
        private PaginationFilter GeneratePaginationFilter(int pageNumber, int pageSize) 
        {
            return new PaginationFilter()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
