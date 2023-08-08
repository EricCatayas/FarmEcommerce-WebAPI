
using Ecommerce.Domain.Entities;
using FarmEcommerce.WebUI.ApiModels;

namespace FarmEcommerce.Core.ServiceContracts.Addresses
{
    public interface IAddressCreateService
    {
        public Task<Address> CreateAsync(AddressCreateDTO address);
    }
}
