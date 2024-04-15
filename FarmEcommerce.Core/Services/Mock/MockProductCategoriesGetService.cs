
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockProductCategoriesGetService : IProductCategoriesGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockProductCategoriesGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<IEnumerable<ProductCategoryDTO>> GetAllAsync()
        {
            try
            {
                string filePath = Path.Combine(_dataFilePath.Get(), "productCategoryDTOs.json");

                string jsonText = File.ReadAllText(filePath);

                ProductCategoryDTO[] productCategories  = JsonConvert.DeserializeObject<ProductCategoryDTO[]>(jsonText);

                return Task.FromResult<IEnumerable<ProductCategoryDTO>>(productCategories);
            }
            catch
            {
                throw;
            }
        }
    }
}
