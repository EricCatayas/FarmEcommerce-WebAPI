
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Image
{
    public interface IImageUploadCreateService
    {
        public Task<Image_Upload> UploadAsync(int images_Id, byte[] imageByte);
        public Task<IEnumerable<Image_Upload>> UploadRangeAsync(int images_Id, IEnumerable<byte[]> imageByteList);
    }
}
