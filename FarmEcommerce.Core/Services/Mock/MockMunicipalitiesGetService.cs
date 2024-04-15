
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.Core.ServiceContracts.Mock;
using Newtonsoft.Json;

namespace FarmEcommerce.Core.Services.Mock
{
    public class MockMunicipalitiesGetService : IMunicipalitiesGetService
    {
        private readonly IDataFilePath _dataFilePath;

        public MockMunicipalitiesGetService(IDataFilePath dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public Task<IEnumerable<Municipality>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Municipality>> GetByProvince(int province_Id)
        {
            string filePath = Path.Combine(_dataFilePath.Get(), "municipalities.json");

            string jsonText = File.ReadAllText(filePath);

            IEnumerable<Municipality> result = JsonConvert.DeserializeObject<Municipality[]>(jsonText).ToList();

            return Task.FromResult<IEnumerable<Municipality>>(result.Where(x => x.Province_Id == province_Id));
        }
    }
}
