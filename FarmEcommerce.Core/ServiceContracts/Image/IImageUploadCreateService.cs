
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageUploadService
    {
        public Task<Image_Upload> UploadAsync(int images_Id, byte[] imageByte);
        public Task<IEnumerable<Image_Upload>> UploadImagesAsync(int images_Id, IEnumerable<byte[]> imageByteList);
    }
}
