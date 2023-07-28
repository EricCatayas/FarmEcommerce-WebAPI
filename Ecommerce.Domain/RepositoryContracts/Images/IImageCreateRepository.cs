
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    public interface IImageCreateRepository
    {
        public Task<int> GetImageId();
    }
}
