
using Bogus;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Images;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.Services.Image;
using MediaStorageServices.Interfaces.v1;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Moq;

namespace FarmEcommerce.UnitTests.Core.ImageUploads
{
    public class ImageUploadCreateServiceTest
    {
        private readonly IImageUploadCreateService _imageUploadCreateService;
        private readonly Mock<IRepository<Image_Upload>> _mockImageUploadsRepo = new();
        private readonly Mock<IImageUploaderService> _mockImageUploader = new();
        public ImageUploadCreateServiceTest()
        {
            _imageUploadCreateService = new ImageUploadCreateService(_mockImageUploadsRepo.Object);
        }
        [Fact]
        // TODO: Fix
        public void UploadAsync_ImageUploadFailure_ToThrowImageUploadException()
        {
            var images_id = new Random().Next(2000);

            _mockImageUploader.Setup(x => x.UploadAsync(It.IsAny<byte[]>())).Throws<Exception>();

            /*Assert.ThrowsAsync<ImageUploadException>(async () =>
            {
                throw new ArgumentException("TODO");
                await _imageUploadCreateService.AddRangeAsync(images_id, imageByte);
            });*/
        }
        [Fact]
        public void UploadAsync_ImageUploadSuccess_ToReturnValidImageUpload()
        {
            //TODO
        }
        private static byte[] GenerateRandomByteArray(int length)
        {
            var random = new Random();
            byte[] byteArray = new byte[length];
            random.NextBytes(byteArray);
            return byteArray;
        }
    }
}
