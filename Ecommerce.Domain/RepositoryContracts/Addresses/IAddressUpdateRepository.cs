
namespace Ecommerce.Domain.RepositoryContracts.Addresses
{
    public interface IAddressUpdateRepository
    {
        public Task<Address> UpdateAsync(Address address);
    }
}
