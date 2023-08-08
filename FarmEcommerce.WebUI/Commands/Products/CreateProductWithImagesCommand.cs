
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Image;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Products
{
    public class CreateProductWithImagesCommand : ProductCreateDTO, IRequest<Product>
    {
        public CreateProductWithImagesCommand(ProductCreateDTO product)
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
    public class CreateProductWithImagesCommandHandler : IRequestHandler<CreateProductWithImagesCommand, Product>
    {
        private readonly IProductCreateService _createService;
        private readonly IImageUploadService _uploadService;

        public CreateProductWithImagesCommandHandler(IProductCreateService productCreateService, IImageUploadService imageUploadService)
        {
            _createService = productCreateService;
            _uploadService = imageUploadService;
        }

        public async Task<Product> Handle(CreateProductWithImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _createService.AddProduct(request);
                // Upload image
                if (request.image_File != null && request.image_File.Length > 0 && request.image_File.ContentType.StartsWith("image/"))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.image_File.CopyToAsync(memoryStream);
                        byte[] fileData = memoryStream.ToArray();
                        await _uploadService.UploadAsync(product.Images_Id, fileData);
                    }
                }

                // Return a successful Result if everything executed without exceptions
                return product;
            }
            catch
            {
                throw;
            }
        }
    }
}
