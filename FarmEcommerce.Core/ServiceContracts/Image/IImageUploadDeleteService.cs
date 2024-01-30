
namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageUploadDeleteService
    {
        public Task DeleteAsync(int image_upload_id);
    }
}
