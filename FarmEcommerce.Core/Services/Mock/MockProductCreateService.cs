
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.ServiceContracts.Mock;
using FarmEcommerce.Core.ServiceContracts.ProductCategories;
using FarmEcommerce.Core.ServiceContracts.Products;
using Newtonsoft.Json;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockProductCreateService : IProductCreateService
    {
        private readonly IDataFilePath _dataFilePath;
        private readonly IProductCategoriesGetService _productCategoriesGetService;

        public MockProductCreateService(IDataFilePath dataFilePath, IProductCategoriesGetService productCategoriesGetService)
        {
            _dataFilePath = dataFilePath;
            _productCategoriesGetService = productCategoriesGetService;
        }
        public async Task<ProductDTO> AddAsync(ProductCreateDTO product)
        {
            try
            {

                string filePath = Path.Combine(_dataFilePath.Get(), "products.json");

                var jsonData = File.ReadAllText(filePath);
                var productList = JsonConvert.DeserializeObject <Product[]>(jsonData).ToList();

                var newProduct = product.ToProduct();

                newProduct.Id = GetProductId(productList);
                newProduct.Images_Id = GetImagesId(productList);
                newProduct.Store_Id = GetStore().Id;
                newProduct.Store = GetStore();
                newProduct.Category = await GetCategory(product.Category_Id);

                productList.Add(newProduct);

                jsonData = JsonConvert.SerializeObject(productList, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);

                var result = new ProductDTO(newProduct);
                return result;
            }
            catch
            {
                throw;
            }
        }

        private int GetProductId(List<Product> productList)
        {
            int maxProductId = productList.Select(x => x.Id).Max();

            return maxProductId + 1000;
        }

        private async Task<Product_Category> GetCategory(int? category_Id)
        {
            try
            {

                var parentCategories = await _productCategoriesGetService.GetAllAsync();
                var flattenedList = new List<ProductCategoryDTO>();

                foreach (var cat in parentCategories)
                {
                    flattenedList.Add(cat);
                    if (cat.SubCategories.Any())
                        flattenedList.AddRange(cat.SubCategories);
                    
                }

                var category = flattenedList.FirstOrDefault(x => x.Id == category_Id);            

                return new Product_Category()
                {
                    Id = category.Id,
                    Parent_Category_Id = category.Parent_Category_Id,
                    Category_Name = category.Name,
                    Image_Url = category.Image_Url
                };
            }
            catch
            {
                throw new ArgumentException("Category does not exists.");
            }
        }

        private Store GetStore()
        {
            return new Store()
            {
                Id = 2,
                Name = "test1's Store",
                Description = null,
                Established_Date = new DateTime(2023, 07, 31, 16, 50, 58),
                Address = GetAddress(),
                Images = null,
                Images_Id = 2003,
                Owner_Id = Guid.Parse("a98a893f-ccbe-457e-a9a2-894aaa89df9e"),
            };
        }

        private Address GetAddress()
        {
            return new Address()
            {
                Street = "Sample Street",
                Barangay = "Sample Barangay",
                Postal_Code = "12345",
                Latitude = 0.0,
                Longitude = 0.0,
                Municipality = new Municipality()
                {
                    Name = "Medellin",
                    Province = new Province()
                    {
                        Name = "Cebu",
                        Id = 72200000
                    },
                    Province_Id = 72200000,
                    Id = 72231000
                },
                Municipality_Id = 72231000,
                Id = 1
            };
        }                

        private int GetImagesId(List<Product>? productList)
        {
            int maxImagesId = productList.Select(x => x.Images_Id).Max();

            return maxImagesId + 1000;
        }
    }
}
