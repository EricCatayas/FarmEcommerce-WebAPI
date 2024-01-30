using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Image;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;

namespace FarmEcommerce.Core.Services.Image
{
    public class ImageUploadCreateService : IImageUploadCreateService
    {
        private readonly IRepository<Image_Upload> _imageUploadRepo;

        public ImageUploadCreateService(IRepository<Image_Upload> imageUploadRepo)
        {
            _imageUploadRepo = imageUploadRepo;
        }
        public async Task<ImageUploadDTO> AddAsync(ImageUploadCreateDTO imageUpload)
        {
            try
            {
                var Image_Upload = new Image_Upload()
                {
                    Images_Id = imageUpload.Images_Id,
                    Image_Url = imageUpload.Image_Url,
                    Upload_Date = DateTime.Now,
                };

                await _imageUploadRepo.AddAsync(Image_Upload);

                return Image_Upload.ToImageUploadDTO();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImageUploadDTO>> AddRangeAsync(IEnumerable<ImageUploadCreateDTO> imageUploads)
        {

            try
            {
                var Image_Uploads = new List<Image_Upload>();

                foreach (var imageUpload in imageUploads)
                {
                    Image_Uploads.Add(new Image_Upload()
                    {
                        Images_Id = imageUpload.Images_Id,
                        Image_Url = imageUpload.Image_Url,
                        Upload_Date = DateTime.Now
                    });
                }

                await _imageUploadRepo.AddRangeAsync(Image_Uploads);

                return Image_Uploads.ToImageUploadDTOs();
            }
            catch
            {
                throw;
            }
        }
    }
}
