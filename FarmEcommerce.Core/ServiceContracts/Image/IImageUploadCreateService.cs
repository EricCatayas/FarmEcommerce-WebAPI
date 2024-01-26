
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageUploadCreateService
    {
        public Task<ImageUploadDTO> AddAsync(ImageUploadCreateDTO imageUpload);
        public Task<IEnumerable<ImageUploadDTO>> AddRangeAsync(IEnumerable<ImageUploadCreateDTO> imageUploads);
    }
}
