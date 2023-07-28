
namespace Ecommerce.Domain.RepositoryContracts.Products
{
    public interface IProductCreateRepository
    {
        public Task<Product> CreateAsync(Product product);
    }
}
