
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
        private readonly IRepository<Images> _imagesRepo;

        public ProductCreateService(IRepository<Product> productRepository, IRepository<Images> imagesRepo, IGetSignedInUserService signedInUserService)
        {
            _produtRepo = productRepository;
            _signedInUserService = signedInUserService;
            _imagesRepo = imagesRepo;
        }
        public async Task<Product> AddProduct(ProductCreateDTO product)
        {
            if(ValidationHelper.ModelInValid(product, out string message))
            {
                throw new ArgumentException(message);
            }

            Product product_ToAdd = product.ToProduct();
            // Get Images
            var images = await _imagesRepo.AddAsync(new Images());
            product_ToAdd.Images_Id = images.Id;
            // Get Store_Id
            var user = await _signedInUserService.GetSignedInUser();
            if(user != null && user.Store_Id != null)            
                product_ToAdd.Store_Id = (int)user.Store_Id;
            else                 
                throw new RequestDeniedException("User must register store first");      
                       
            try
            {
                var result = await _produtRepo.AddAsync(product_ToAdd);
                // _produtRepo.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                await _imagesRepo.DeleteAsync(images);
                throw;
            }
        }
    }
}
