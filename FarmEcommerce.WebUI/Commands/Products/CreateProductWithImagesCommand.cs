
using Azure.Core;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.WebUI.Common.Helpers;
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
        private readonly IImageUploadCreateService _imageUploadService;

        public CreateProductAndUploadImagesCommandHandler(IProductCreateService productCreateService, IImageUploadCreateService imageUploadService)
        {
            _createService = productCreateService;
            _imageUploadService = imageUploadService;
        }

        public async Task<ProductDTO> Handle(CreateProductAndUploadImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _createService.AddAsync(request.GetProductCreateDTO());
                // Upload image
                if (!request.image_Files.IsNullOrEmpty())
                {
                    var image_Uploads = await UploadImagesAsync(product.GetImagesID(), request.image_Files);
                    product.Images = image_Uploads.ToImageUploadDTOs();
                }

                return product;
            }
            catch
            {
                throw;
            }
        }
        private async Task<IEnumerable<Image_Upload>> UploadImagesAsync(int imagesId, IEnumerable<IFormFile> imageFiles)
        {
            List<byte[]> imageFilesInBytes = new List<byte[]>();
            foreach (var imageFile in imageFiles)
            {
                if (ImageFileValidator.Validate(imageFile))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(memoryStream);
                        byte[] fileData = memoryStream.ToArray();
                        imageFilesInBytes.Add(fileData);
                    }
                }

            }
            return await _imageUploadService.UploadRangeAsync(imagesId, imageFilesInBytes);
        }
    }
}
