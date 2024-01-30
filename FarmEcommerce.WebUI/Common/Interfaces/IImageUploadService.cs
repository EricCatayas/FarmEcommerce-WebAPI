namespace FarmEcommerce.WebUI.Common.Interfaces
{
    /// <summary>
    /// Defines a method for uploading IFormFile images.
    /// </summary>
    public interface IImageUploadService
    {
        /// <summary>
        /// Uploads an image asynchronously.
        /// </summary>
        /// <param name="file">The image file to upload.</param>
        /// <returns>
        /// The URL or identifier of the uploaded image.
        /// </returns>
        Task<string> UploadAsync(IFormFile file);
    }
}
