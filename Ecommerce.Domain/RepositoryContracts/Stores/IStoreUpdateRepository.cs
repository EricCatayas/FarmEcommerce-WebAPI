
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.RepositoryContracts.Stores
{
    public interface IStoreUpdateRepository
    {
        public Task<Store> UpdateAsync(Store store);
    }
}
