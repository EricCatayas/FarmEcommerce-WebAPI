using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Addresses;
using FarmEcommerce.Core.ServiceContracts.Addresses;

namespace FarmEcommerce.Core.Services.Addresses
{
    public class ProvincesGetService : IProvincesGetService
    {
        private readonly IProvincesGetRepository _provincesGetRepo;

        public ProvincesGetService(IProvincesGetRepository provincesGetRepo)
        {
            _provincesGetRepo = provincesGetRepo;
        }
        public async Task<IEnumerable<Province>> GetProvinces()
        {
            return await _provincesGetRepo.GetAll();
        }
    }
}
