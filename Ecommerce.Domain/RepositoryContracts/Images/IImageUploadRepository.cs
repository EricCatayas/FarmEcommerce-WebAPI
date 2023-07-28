
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    public interface IImageUploadRepository
    {
        public Task<int> UploadAsync(int images_Id, byte[] imageData);
        public Task<int> UploadImagesAsync(int images_Id, IEnumerable<byte[]> imageDataList);
    }
}
