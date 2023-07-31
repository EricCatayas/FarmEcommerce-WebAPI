
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    [Obsolete("Recommend using IRepository<Images>")]
    public interface IImageDeleteRepository
    {
        public Task<bool> DeleteAsync(int images_Id);
    }
}
