
namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageGetService
    {
        public Task<string> GetImage(int images_id);
        public Task<IEnumerable<string>> GetImages(int images_id);
    }
}
