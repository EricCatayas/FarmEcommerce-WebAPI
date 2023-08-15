
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Addresses;
using FarmEcommerce.Core.ServiceContracts.Addresses;

namespace FarmEcommerce.Core.Services.Addresses
{
    public class MunicipalitiesGetService : IMunicipalitiesGetService
    {
        private readonly IMunicipalitiesGetRepository _municipalitiesGetRepo;

        public MunicipalitiesGetService(IMunicipalitiesGetRepository municipalitiesGetRepo)
        {
            _municipalitiesGetRepo = municipalitiesGetRepo;
        }
        public Task<IEnumerable<Municipality>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Municipality>> GetByProvince(int province_Id)
        {
            return await _municipalitiesGetRepo.GetAsync(province_Id);
        }
    }
}
