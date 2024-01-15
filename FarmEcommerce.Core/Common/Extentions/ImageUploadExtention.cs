
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.Common.Extentions
{
    public static class ImageUploadExtention
    {
        public static IEnumerable<ImageUploadDTO> ToImageUploadDTOs(this IEnumerable<Image_Upload> image_Uploads)
        {
            return image_Uploads.Select(upload => upload.ToImageUploadDTO());
        }
        public static ImageUploadDTO ToImageUploadDTO(this Image_Upload upload)
        {
            return
                new ImageUploadDTO()
                {
                    Image_Url = upload.Image_Url,
                    Upload_Date = upload.Upload_Date,
                };
        }
    }
}
