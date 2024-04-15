using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.Products;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockFilteredProductsGetService : IFilteredProductsGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockFilteredProductsGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<IEnumerable<ProductDTO>> GetFilteredProducts(ProductsFilterDTO filterDTO)
        {
            try
            {
                string filePath = Path.Combine(_dataFilePath.Get(), "products.json");

                string jsonText = File.ReadAllText(filePath);

                IEnumerable<Product> products = JsonConvert.DeserializeObject<Product[]>(jsonText).ToList();

                if (filterDTO.Store_Id != null)
                    products = products.Where(p => p.Store_Id == filterDTO.Store_Id);

                if (filterDTO.Category_Id != null)
                    products = products.Where(p => p.Category_Id == filterDTO.Category_Id);

                if (!string.IsNullOrEmpty(filterDTO.Name))
                {
                    string nameFilter = filterDTO.Name.ToLower();
                    products = products.Where(p => p.Name.ToLower().Contains(nameFilter));
                }

                if (filterDTO.Max_Price != null)
                    products = products.Where(p => p.Price <= filterDTO.Max_Price);

                if (filterDTO.Min_Price != null)
                    products = products.Where(p => p.Price >= filterDTO.Min_Price);

                if (filterDTO.Is_Negotiable != null)
                    products = products.Where(p => p.Is_Negotiable == filterDTO.Is_Negotiable);

                return Task.FromResult(products.Select(p => new ProductDTO(p)));

            }
            catch
            {
                throw;
            }
        }
    }
}
