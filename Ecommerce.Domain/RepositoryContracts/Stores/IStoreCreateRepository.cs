
namespace Ecommerce.Domain.RepositoryContracts.Stores
{
    public interface IStoreCreateRepository
    {
        public Task<Store> CreateAsync(Store store);
    }
}
