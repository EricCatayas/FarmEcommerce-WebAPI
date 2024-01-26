using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.WebUI.Common.Interfaces;
using MediaStorageServices.Interfaces.v2;

namespace FarmEcommerce.WebUI.Common.Services
{
    public class CloudImageUploaderService : IImageUploadService
    {
        private readonly IImageUploaderService _imageUploaderService;

        public CloudImageUploaderService(IImageUploaderService imageUploaderService)
        {
            _imageUploaderService = imageUploaderService;
        }
        public async Task<string> UploadAsync(IFormFile imageFile)
        {
            try
            {
                using (Stream stream = imageFile.OpenReadStream())
                {
                    var filename = imageFile.FileName;
                    var contentType = imageFile.ContentType;
                    return await _imageUploaderService.UploadAsync(stream, filename, contentType);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                throw new ImageUploadException();
            }
        }
    }
}
