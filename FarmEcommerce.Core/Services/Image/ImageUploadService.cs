
using FarmEcommerce.Core.ServiceContracts.Image;

namespace FarmEcommerce.Core.Services.Image
{
    public class ImageUploadService : IImageUploadService
    {
        public Task<int> UploadAsync(int images_Id, byte[] imageData)
        {
            throw new NotImplementedException();
        }

        public Task<int> UploadImagesAsync(int images_Id, IEnumerable<byte[]> imageDataList)
        {
            throw new NotImplementedException();
        }
    }
}
