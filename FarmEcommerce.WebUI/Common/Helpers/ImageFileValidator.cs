
using Microsoft.AspNetCore.Http;

namespace FarmEcommerce.WebUI.Common.Helpers
{
    public static class ImageFileValidator
    {
        public static bool Validate(IFormFile imageFile)
        {
            return imageFile != null && imageFile.Length > 0 && imageFile.ContentType.StartsWith("image/");
        }
    }
}
