using Azure.Storage.Blobs;
using Ecommerce.Domain.RepositoryContracts.Images;
using Microsoft.Extensions.Configuration;
using System.Drawing.Imaging;
using System.Drawing;
using Azure.Storage.Blobs.Models;
using Azure;
using static System.Net.Mime.MediaTypeNames;

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
                string imageName = "lovelove"; 
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                BlobClient blobClient = containerClient.GetBlobClient(imageName);
                using (var imageStream = new MemoryStream(imageData))
                {

                    using (var bitmap = new Bitmap(image, new Size(IMAGE_WIDTH, IMAGE_HEIGHT)))
                    {
                        // Save the resized image to a memory stream
                        using (var resizedImageStream = new MemoryStream())
                        {
                            bitmap.Save(resizedImageStream, ImageFormat.Jpeg);

                            // Upload the resized image to Azure Blob Storage
                            resizedImageStream.Position = 0;
                            await blobClient.UploadAsync(resizedImageStream, new BlobUploadOptions
                            {
                                HttpHeaders = new BlobHttpHeaders { ContentType = "image/jpeg" }, // Set the content type
                                Conditions = new BlobRequestConditions { IfNoneMatch = ETag.All } // You can specify upload conditions if needed
                            });
                        }
                    }
                }

                return blobClient.Uri.ToString();
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<string>> UploadImagesAsync(IEnumerable<byte[]> imageDataList)
        {
            throw new NotImplementedException();
        }
    }
}
