namespace FarmEcommerce.WebUI.Common.Interfaces
{
    public interface IImageUploadService
    {
        public Task<string> UploadAsync(IFormFile file);
    }
}
