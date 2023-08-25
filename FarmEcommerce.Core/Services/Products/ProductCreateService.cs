using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.Common.Helpers;
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
            product_ToAdd.Images_Id = await GetImagesIdForProduct();

            try
            {
                var user = await _signedInUserService.GetSignedInUser();
                // Get Store_Id
                if(user.Store_Id != null)            
                    product_ToAdd.Store_Id = (int)user.Store_Id;
                else                 
                    throw new UnathorizedRequestException("User must register store first");      
                       
                var result = await _produtRepo.AddAsync(product_ToAdd);
                return result;
            }
            catch
            {
                await _imagesRepo.DeleteAsync(product_ToAdd.Images);
                throw;
            }
        }
        private async Task<int> GetImagesIdForProduct()
        {
            var imagesForProduct = await _imagesRepo.AddAsync(new Images());
            return imagesForProduct.Id;
        }
    }
}
