
namespace FarmEcommerce.Core.Common.Exceptions
{
    public class ImageUploadException : Exception
    {
        /// <summary>
        /// Default message: "An error occured while uploading image."
        /// </summary>
        public ImageUploadException() : base("An error occured while uploading image.")
        {
            
        }
        public ImageUploadException(string message) : base(message)
        {
            
        }
    }
}
