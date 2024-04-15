
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockPaginatedProductsGetService : IPaginatedProductsGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockPaginatedProductsGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<IEnumerable<ProductDTO>> GetAsync(PaginationFilter filter)
        {
            try
            {
                if (filter.PageNumber < 1)
                    throw new ArgumentException("Page number must not be 0 or below");
                if (filter.PageSize < 1)
                    throw new ArgumentException("Page size must not be 0 or below");

                string filePath = Path.Combine(_dataFilePath.Get(), "products.json");

                string jsonText = File.ReadAllText(filePath);

                List<Product> products = JsonConvert.DeserializeObject<Product[]>(jsonText).ToList();

                var skip = (filter.PageNumber - 1) * filter.PageSize;
                var result = products.Skip(skip).Take(filter.PageSize);

                return Task.FromResult(result.Select(x => new ProductDTO(x)));
            }
            catch
            {
                throw;
            }

        }
    }
}
