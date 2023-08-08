using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Addresses
{
    public interface IAddressUpdateService
    {
        Task<Result> UpdateAsync(AddressUpdateDTO address);
    }
}
