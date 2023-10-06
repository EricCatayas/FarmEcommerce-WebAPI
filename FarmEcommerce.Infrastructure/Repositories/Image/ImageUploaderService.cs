using Azure.Storage.Blobs;
using Ecommerce.Domain.RepositoryContracts.Images;
using Microsoft.Extensions.Configuration;
using System.Drawing.Imaging;
using System.Drawing;
using Azure.Storage.Blobs.Models;
using Azure;
using static System.Net.Mime.MediaTypeNames;
using FarmEcommerce.Core.Common.Exceptions;

namespace FarmEcommerce.Infrastructure.Repositories.Image
{
    public class ImageUploaderService : IImageUploader
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        private const int IMAGE_WIDTH = 150;
        private const int IMAGE_HEIGHT = 150;
        public ImageUploaderService(IConfiguration config)
        {
            _connectionString = config["StorageAccountConnectionString"].ToString();
            _containerName = config["BlobContainerName"].ToString();
        }

        public async Task<string> UploadAsync(byte[] imageData)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                string ImageUri = await UploadImageUsingBlobService(imageData, containerClient);

                return ImageUri;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> UploadRangeAsync(IEnumerable<byte[]> imageDataList)
        {
            List<string> uploadedImageUrls = new List<string>();

            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                foreach (var imageData in imageDataList)
                {
                    // Generate a unique image name or use an appropriate naming convention
                    string imageUri = await UploadImageUsingBlobService(imageData, containerClient);

                    uploadedImageUrls.Add(imageUri);
                    
                }
            }
            catch
            {
                throw;
            }

            return uploadedImageUrls;
        }
        private async Task<string> UploadImageUsingBlobService(byte[] imageData, BlobContainerClient containerClient)
        {
            string imageName = GenerateImageName();

            BlobClient blobClient = containerClient.GetBlobClient(imageName);
            using (var imageStream = new MemoryStream(imageData))
            {

                await blobClient.UploadAsync(imageStream, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "image/jpeg" }, // Set the content type
                    Conditions = new BlobRequestConditions { IfNoneMatch = ETag.All } // You can specify upload conditions if needed
                });
            }

            return blobClient.Uri.ToString();
        }
        private string GenerateImageName()
        {
            return Guid.NewGuid().ToString() + ".jpeg";
        }
    }
}
