
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Images
{
    public interface IImageDeleteService
    {
        public Task<Result> UploadAsync(int image_upload_id);
    }
}
