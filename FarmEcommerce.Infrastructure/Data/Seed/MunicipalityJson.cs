
namespace FarmEcommerce.Infrastructure.Data.Seed
{
    public record MunicipalityJson
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string OldName { get; set; }
        public bool IsCapital { get; set; }
        public string ProvinceCode { get; set; }
        public bool DistrictCode { get; set; }
        public string RegionCode { get; set; }
        public string IslandGroupCode { get; set; }
        public string Psgc10DigitCode { get; set; }
    }
}
