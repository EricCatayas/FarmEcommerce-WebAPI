
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Images;
using FarmEcommerce.Core.ServiceContracts.Image;
using Microsoft.Extensions.Configuration;

namespace FarmEcommerce.Core.Services.Image
{
    public class ImageUploadCreateService : IImageUploadCreateService
    {
        private readonly IImageUploader _imageUploader;

        public ImageUploadCreateService(IImageUploader imageUploader)
        {
            _imageUploader = imageUploader;
        }

        public Task<Image_Upload> UploadAsync(int images_Id, byte[] imageByte)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image_Upload>> UploadImagesAsync(int images_Id, IEnumerable<byte[]> imageByteList)
        {
            throw new NotImplementedException();
        }
    }
}
