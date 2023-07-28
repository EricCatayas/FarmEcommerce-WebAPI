
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Images;
using Ecommerce.Domain.RepositoryContracts.Products;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductCreateService : IProductCreateService
    {
        private readonly IRepository<Product> _produtRepo;
        private readonly IGetSignedInUserService _signedInUserService;
        private readonly IImageCreateRepository _imageCreateRepo;
        

        public ProductCreateService(IRepository<Product> productRepository, IGetSignedInUserService signedInUserService, IImageCreateRepository imageCreateRepository)
        {
            _produtRepo = productRepository;
            _signedInUserService = signedInUserService;
            _imageCreateRepo = imageCreateRepository;
        }
        public async Task<Product> AddProduct(ProductCreateDTO product)
        {
            if(ValidationHelper.ModelInValid(product, out string message))
            {
                throw new ArgumentException(message);
            }

            Product product_ToAdd = product.ToProduct();
            // Get Images
            product_ToAdd.Images_Id = await _imageCreateRepo.GetImageId();
            // Get Store_Id
            var user = await _signedInUserService.GetSignedInUser();
            if(user != null && user.Store_Id != null)            
                product_ToAdd.Store_Id = (int)user.Store_Id;
            else                 
                throw new RequestDeniedException("User must register store first");      
                       
            try
            {
                return await _produtRepo.AddAsync(product_ToAdd);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
