
namespace Ecommerce.Domain.RepositoryContracts.Products
{
    public interface IProductDeleteRepository
    {
        public Task<bool> DeleteAsync(int id);
    }
}
