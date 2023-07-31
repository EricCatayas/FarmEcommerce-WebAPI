
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    [Obsolete("Recommend using IRepository<Images>")]
    public interface IImageCreateRepository
    {
        public Task<int> CreateAsync();
    }
}
