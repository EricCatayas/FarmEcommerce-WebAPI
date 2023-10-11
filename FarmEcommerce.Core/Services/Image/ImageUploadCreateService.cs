
using Ecommerce.Domain.Entities;
using MediaStorageServices.Interfaces;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Image;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Image
{
    public class ImageUploadCreateService : IImageUploadCreateService
    {
        private readonly IImageUploaderService _imageUploader;
        private readonly IRepository<Image_Upload> _imageUploadRepo;

        public ImageUploadCreateService(IRepository<Image_Upload> imageUploadRepo, IImageUploaderService imageUploader)
        {
            _imageUploader = imageUploader;
            _imageUploadRepo = imageUploadRepo;
        }

        public async Task<Image_Upload> UploadAsync(int images_Id, byte[] imageByte)
        {
            try
            {
                string Image_Uri = await _imageUploader.UploadAsync(imageByte);

                var Image_Upload = new Image_Upload()
                {
                    Images_Id = images_Id,
                    Image_Url = Image_Uri,
                    Upload_Date = DateTime.Now,
                };

                await _imageUploadRepo.AddAsync(Image_Upload);

                return Image_Upload;
            }
            catch(Exception ex)
            {
                throw new ImageUploadException(ex.Message);
            }
        }

        public async Task<IEnumerable<Image_Upload>> UploadRangeAsync(int images_Id, IEnumerable<byte[]> imageByteList)
        {

            try
            {
                var ImageUriList = await _imageUploader.UploadRangeAsync(imageByteList);

                var Image_Uploads = new List<Image_Upload>();

                foreach (var image_uri in ImageUriList)
                {
                    Image_Uploads.Add(new Image_Upload()
                    {
                        Images_Id = images_Id,
                        Image_Url = image_uri,
                        Upload_Date = DateTime.Now
                    });
                }

                await _imageUploadRepo.AddRangeAsync(Image_Uploads);

                return Image_Uploads;
            }
            catch(Exception ex)
            {
                throw new ImageUploadException(ex.Message);
            }
        }
    }
}
