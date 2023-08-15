
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Addresses
{
    public interface IProvincesGetService
    {
        public Task<IEnumerable<Province>> GetProvinces();
    }
}
