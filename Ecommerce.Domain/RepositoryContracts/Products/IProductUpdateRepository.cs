
namespace Ecommerce.Domain.RepositoryContracts.Products
{
    public interface IProductUpdateRepository
    {
        public Task<Product> Update(Product product);
    }
}
