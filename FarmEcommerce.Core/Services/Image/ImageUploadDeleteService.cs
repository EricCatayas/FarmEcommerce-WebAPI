
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Image;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Image
{
    public class ImageUploadDeleteService : IImageUploadDeleteService
    {
        private readonly IRepository<Image_Upload> _imageUploadRepo;

        public ImageUploadDeleteService(IRepository<Image_Upload> imageUploadRepo)
        {
            _imageUploadRepo = imageUploadRepo;
        }
        public async Task DeleteAsync(int image_upload_id)
        {
            var image = await _imageUploadRepo.GetByIdAsync(image_upload_id);

            if (image == null)
            {
                throw new DataNotFoundException(typeof(Image_Upload), image_upload_id);
            }
            await _imageUploadRepo.DeleteAsync(image);

            return;
        }
    }
}
