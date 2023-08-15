
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FarmEcommerce.Infrastructure.Data.Seed
{
    public static class MunicipalitiesSeedingData
    {
        public static void SeedMunicipalities(this ModelBuilder builder)
        {
            string municipality_json = File.ReadAllText("C:\\Users\\ACER\\Desktop\\Conquest\\ASPNET\\FarmEcommerce\\FarmEcommerce.Infrastructure\\Data\\Seed\\municipalities.json");

            List<MunicipalityJson> municipalityData = JsonConvert.DeserializeObject<List<MunicipalityJson>>(municipality_json);
            List<Municipality> municipalityList = new List<Municipality>();

            foreach (var data in municipalityData)
            {
                int code = int.Parse(data.Code);
                string name = data.Name;
                int province_code = int.Parse(data.ProvinceCode);

                municipalityList.Add(new Municipality { Id = code, Name = name, Province_Id = province_code });
            }

            builder.Entity<Municipality>().HasData(municipalityList);
        }
    }
}
