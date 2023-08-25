
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
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
        public async Task DeleteAsync(int product_Id)
        {
            var product = await  _productRepo.GetByIdAsync(product_Id);
            if (product == null)
            {
                throw new DataNotFoundException(typeof(Product), product_Id);
            }
            await _productRepo.DeleteAsync(product);
        }
    }
}
