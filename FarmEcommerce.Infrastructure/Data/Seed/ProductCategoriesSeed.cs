
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FarmEcommerce.Infrastructure.Data.Seed
{
    public static class ProductCategoriesSeed
    {
        public static void SeedProductCategories(this ModelBuilder builder)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string productCategoriesJsonPath = Path.Combine(currentDirectory, "..\\FarmEcommerce.Infrastructure\\Data\\Seed\\productCategories.json");

            string productCategoriesJsonData = File.ReadAllText(productCategoriesJsonPath);

            List<Product_Category> productCategoriesData = JsonConvert.DeserializeObject<List<Product_Category>>(productCategoriesJsonData);

            builder.Entity<Product_Category>().HasData(productCategoriesData);
        }
    }
}
