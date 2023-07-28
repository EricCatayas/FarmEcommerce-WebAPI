
using System.Linq.Expressions;

namespace Ecommerce.Domain.RepositoryContracts.Images
{
    public interface IImageGetRepository
    {
        public Task<string> GetImage(int images_id);
        public Task<IEnumerable<string>> GetImages(int images_id);
    }
}
