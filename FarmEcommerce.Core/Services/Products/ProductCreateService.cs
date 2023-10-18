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
        private Product _productToAdd;
        private readonly IRepository<Product> _produtRepo;
        private readonly IGetSignedInUserService _signedInUserService;
        private readonly IRepository<Images> _imagesRepo;

        public ProductCreateService(IRepository<Product> productRepository, IRepository<Images> imagesRepo, IGetSignedInUserService signedInUserService)
        {
            _produtRepo = productRepository;
            _signedInUserService = signedInUserService;
            _imagesRepo = imagesRepo;
        }
        public async Task<ProductDTO> AddAsync(ProductCreateDTO product)
        {
            if(ValidationHelper.ModelInValid(product, out string message))
            {
                throw new ArgumentException(message);
            }

            ConvertProductDTOToProduct(product);
            var getImagesTask = GetImagesForProductToAdd();
            var getUserStoreTask = GetUserStoreForProductToAdd();

            try
            {                
                await Task.WhenAll(getImagesTask, getUserStoreTask);
                
                var result = await _produtRepo.AddAsync(_productToAdd);
                return new ProductDTO(result);
            }
            catch
            {                
                await DeleteImagesFromProduct();
                throw;
            }
        }
        private void ConvertProductDTOToProduct(ProductCreateDTO productCreateDTO)
        {
            _productToAdd = productCreateDTO.ToProduct();            
        }
        private async Task GetImagesForProductToAdd()
        {
            _productToAdd.Images_Id = await GetImagesIdForProduct();
        }
        private async Task<int> GetImagesIdForProduct()
        {
            var imagesForProduct = await _imagesRepo.AddAsync(new Images());
            return imagesForProduct.Id;
        }
        private async Task GetUserStoreForProductToAdd()
        {
            var user = await _signedInUserService.GetSignedInUser();
            
            if (user.Store_Id != null)
                _productToAdd.Store_Id = (int)user.Store_Id;
            else
                throw new UnathorizedRequestException("User must register store first");
        }
        private async Task DeleteImagesFromProduct()
        {
            await _imagesRepo.DeleteAsync(_productToAdd.Images);
        }
    }
}
