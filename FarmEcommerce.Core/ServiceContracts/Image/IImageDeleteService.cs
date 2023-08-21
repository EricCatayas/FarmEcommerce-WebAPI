
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageDeleteService
    {
        public Task<Result> DeleteAsync(int image_upload_id);
    }
}
