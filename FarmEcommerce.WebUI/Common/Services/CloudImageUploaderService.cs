using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.WebUI.Common.Interfaces;
using MediaStorageServices.Exceptions;
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
                    var filename = ConvertToGuidFilename(imageFile.FileName);
                    var contentType = imageFile.ContentType;
                    return await _imageUploaderService.UploadAsync(stream, filename, contentType);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                throw;
            }
        }
        private string ConvertToGuidFilename(string filename)
        {
            try
            {

                // Get the file extension
                string extension = System.IO.Path.GetExtension(filename);

                // Generate a new GUID filename with the same extension
                string newFilename = $"{Guid.NewGuid()}{extension}";

                return newFilename;
            }
            catch
            {
                throw new Exception("File extension does not exists.");
            }
        }
    }
}
