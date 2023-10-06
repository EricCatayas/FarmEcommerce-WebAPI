
namespace Ecommerce.Domain.RepositoryContracts.Images
{
    public interface IImageUploader
    {
        public Task<string> UploadAsync(byte[] imageData);
        public Task<IEnumerable<string>> UploadRangeAsync(IEnumerable<byte[]> imageDataList);
    }
}
