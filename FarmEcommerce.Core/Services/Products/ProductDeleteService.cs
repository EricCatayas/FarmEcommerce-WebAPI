
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductDeleteService : IProductDeleteService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductDeleteService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Result> DeleteAsync(int product_Id)
        {
            var product = await  _productRepo.GetByIdAsync(product_Id);
            if (product == null)
            {
                return Result.Failure(new List<string>() { "Product not found. " });             
            }
            await _productRepo.DeleteAsync(product);
            return Result.Success();
        }
    }
}
