using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.Core.ServiceContracts.Mock;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockProvincesGetService : IProvincesGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockProvincesGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public Task<IEnumerable<Province>> GetProvinces()
        {
            string filePath = Path.Combine(_dataFilePath.Get(), "provinces.json");

            string jsonText = File.ReadAllText(filePath);

            IEnumerable<Province> result = JsonConvert.DeserializeObject<Province[]>(jsonText).ToList();

            return Task.FromResult<IEnumerable<Province>>(result);
        }
    }
}
