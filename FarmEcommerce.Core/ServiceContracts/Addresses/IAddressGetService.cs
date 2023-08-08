
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Addresses
{
    public interface IAddressGetService
    {
        public Task<Address> GetAddress(int id);
        public Task<IEnumerable<Address>> GetUserAddressList(Guid user_Id);
    }
}
