
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    public interface IImageDeleteRepository
    {
        public Task<bool> DeleteAsync(int image_Id);
    }
}
