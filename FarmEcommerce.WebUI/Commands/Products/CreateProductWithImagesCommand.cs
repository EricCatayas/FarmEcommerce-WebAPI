
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.WebUI.Common.Helpers;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Products
{
    public class CreateProductAndUploadImagesCommand : ProductCreateDTO, IRequest<Product>
    {
        public CreateProductAndUploadImagesCommand(ProductCreateDTO product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Is_Negotiable = product.Is_Negotiable;
            Per_Qty_Type = product.Per_Qty_Type;
            Qty_In_Stock = product.Qty_In_Stock;
            Category_Id = product.Category_Id;
        }
        public IFormFile? image_File { get; set; }    
    }
    public class CreateProductAndUploadImagesCommandHandler : IRequestHandler<CreateProductAndUploadImagesCommand, Product>
    {
        private readonly IProductCreateService _createService;
        private readonly IImageUploadCreateService _imageUploadService;

        public CreateProductAndUploadImagesCommandHandler(IProductCreateService productCreateService, IImageUploadCreateService imageUploadService)
        {
            _createService = productCreateService;
            _imageUploadService = imageUploadService;
        }

        public async Task<Product> Handle(CreateProductAndUploadImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _createService.AddProduct(request);
                // Upload image
                if (request.image_File != null && ImageFileValidator.Validate(request.image_File))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.image_File.CopyToAsync(memoryStream);
                        byte[] fileData = memoryStream.ToArray();
                        await _imageUploadService.UploadAsync(product.Images_Id, fileData);
                    }
                }

                return product;
            }
            catch
            {
                throw;
            }
        }
    }
}
