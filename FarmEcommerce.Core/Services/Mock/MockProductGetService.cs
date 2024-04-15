
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.Products;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockProductGetService : IProductGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockProductGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<ProductDTO> GetProduct(int product_id)
        {
            try
            {
                string filePath = Path.Combine(_dataFilePath.Get(), "products.json");

                string jsonText = File.ReadAllText(filePath);

                Product[] products = JsonConvert.DeserializeObject<Product[]>(jsonText);

                ProductDTO result = new ProductDTO(products.First(x => x.Id == product_id));

                return Task.FromResult<ProductDTO>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
