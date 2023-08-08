
namespace Ecommerce.Domain.RepositoryContracts.Stores
{
    public interface IStoreGetRepository
    {
        Task<Store> GetByIdAsync(int store_Id);
    }
}
