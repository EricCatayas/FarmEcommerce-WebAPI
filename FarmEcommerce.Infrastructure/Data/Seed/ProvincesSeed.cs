
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FarmEcommerce.Infrastructure.Data.Seed
{
    public static class ProvinceSeedingData
    {
        public static void SeedProvinces(this ModelBuilder builder)
        {
            string province_json = File.ReadAllText("C:\\Users\\ACER\\Desktop\\Conquest\\ASPNET\\FarmEcommerce\\FarmEcommerce.Infrastructure\\Data\\Seed\\provinces.json");

            List<Dictionary<string, string>> provinceData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(province_json);
            List<Province> provinceList = new List<Province>();

            foreach (var data in provinceData)
            {
                int code = int.Parse(data["code"]);
                string name = data["name"];

                provinceList.Add(new Province { Id = code, Name = name });
            }


            builder.Entity<Province>().HasData(provinceList);
        }
    }
}
