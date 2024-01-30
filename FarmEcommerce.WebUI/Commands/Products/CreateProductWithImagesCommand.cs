
using Azure.Core;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.WebUI.Common.Helpers;
using FarmEcommerce.WebUI.Common.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace FarmEcommerce.WebUI.Commands.Products
{
    public class CreateProductAndUploadImagesCommand : IRequest<ProductDTO>
    {
        private ProductCreateDTO product;
        public CreateProductAndUploadImagesCommand(ProductCreateDTO product)
        {
            this.product = product;
        }
        public IEnumerable<IFormFile>? image_Files { get; set; }
        public ProductCreateDTO GetProductCreateDTO()
        {
            return this.product;
        }
    }
    public class CreateProductAndUploadImagesCommandHandler : IRequestHandler<CreateProductAndUploadImagesCommand, ProductDTO>
    {
        private readonly IProductCreateService _createService;
        private readonly IImageUploadCreateService _imageUploadCreateService;
        private readonly IImageUploadService _imageUploadService;

        public CreateProductAndUploadImagesCommandHandler(IProductCreateService productCreateService, IImageUploadCreateService imageUploadCreateService, IImageUploadService imageUploadService)
        {
            _createService = productCreateService;
            _imageUploadCreateService = imageUploadCreateService;
            _imageUploadService = imageUploadService;
        }

        public async Task<ProductDTO> Handle(CreateProductAndUploadImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.image_Files == null)
                    throw new ArgumentException("Product images must not be null.");

                var product = await _createService.AddAsync(request.GetProductCreateDTO());
                // Upload image
                if (!request.image_Files.IsNullOrEmpty())
                {
                    product.Images = await UploadImagesAsync(product.GetImagesID(), request.image_Files);
                }

                return product;
            }
            catch
            {
                throw;
            }
        }
        private async Task<IEnumerable<ImageUploadDTO>> UploadImagesAsync(int imagesId, IEnumerable<IFormFile> imageFiles)
        {
            var imageFilesInBytes = new List<ImageUploadCreateDTO>();
            foreach (var imageFile in imageFiles)
            {
                if (ImageFileValidator.IsValidImageFile(imageFile))
                {
                    var result = await _imageUploadService.UploadAsync(imageFile);
                    imageFilesInBytes.Add(new ImageUploadCreateDTO()
                    {
                        Images_Id = imagesId,
                        Image_Url = result,                        
                    });
                }

            }

            return await _imageUploadCreateService.AddRangeAsync(imageFilesInBytes);
        }
    }
}
