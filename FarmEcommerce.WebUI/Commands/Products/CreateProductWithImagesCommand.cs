
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
        public IEnumerable<IFormFile>? image_Files { get; set; }
        public CreateProductAndUploadImagesCommand(ProductCreateDTO product, IEnumerable<IFormFile> Image_Files)
        {
            this.product = product;
            image_Files = Image_Files;
        }
        public ProductCreateDTO GetProductCreateDTO()
        {
            return this.product;
        }
    }
    public class CreateProductAndUploadImagesCommandHandler : IRequestHandler<CreateProductAndUploadImagesCommand, ProductDTO>
    {
        private readonly IProductCreateService _productCreateService;
        private readonly IImageUploadCreateService _imageUploadCreateService;
        private readonly IImageUploadService _imageUploadService;

        public CreateProductAndUploadImagesCommandHandler(IProductCreateService productCreateService, IImageUploadCreateService imageUploadCreateService, IImageUploadService imageUploadService)
        {
            _productCreateService = productCreateService;
            _imageUploadCreateService = imageUploadCreateService;
            _imageUploadService = imageUploadService;
        }

        public async Task<ProductDTO> Handle(CreateProductAndUploadImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.image_Files.IsNullOrEmpty())
                    throw new ArgumentException("Product images must not be null.");

                else if(!ValidImageTypes(request.image_Files))
                    throw new ArgumentException("Product images must be of valid image type.");

                var product = await _productCreateService.AddAsync(request.GetProductCreateDTO());
                
                // Upload images
                product.Images = await UploadImagesAsync(product.GetImagesID(), request.image_Files);

                return product;
            }
            catch
            {
                throw;
            }
        }

        private bool ValidImageTypes(IEnumerable<IFormFile> image_Files)
        {
            foreach (var imageFile in image_Files)
                if (!ImageFileValidator.IsValidImageFile(imageFile))
                    return false;

            return true;
        }

        private async Task<IEnumerable<ImageUploadDTO>> UploadImagesAsync(int imagesId, IEnumerable<IFormFile> imageFiles)
        {
            var imageUploadList = new List<ImageUploadCreateDTO>();
            foreach (var imageFile in imageFiles)
            {                
                var result = await _imageUploadService.UploadAsync(imageFile);
                imageUploadList.Add(new ImageUploadCreateDTO()
                {
                    Images_Id = imagesId,
                    Image_Url = result,                        
                });

            }

            return await _imageUploadCreateService.AddRangeAsync(imageUploadList);
        }
    }
}
