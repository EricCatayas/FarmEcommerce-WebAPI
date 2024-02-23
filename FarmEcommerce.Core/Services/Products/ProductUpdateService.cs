
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.ServiceContracts.Products;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class ProductUpdateService : IProductUpdateService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductUpdateService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> UpdateProduct(ProductUpdateDTO product)
        {
            if(ValidationHelper.ModelInValid(product, out string message))            
                throw new ArgumentException(message);
            
            var prev_product = await _productRepo.GetByIdAsync(product.Id);
            if(prev_product == null)
                throw new DataNotFoundException(typeof(Product), product.Id);
            
            //Update Product
            prev_product.Name = product.Name;
            prev_product.Description = product.Description;
            prev_product.Quantity_Unit = product.Quantity_Unit;
            prev_product.Qty_In_Stock = product.Qty_In_Stock;
            prev_product.Price = product.Price;
            prev_product.Category_Id = product.Category_Id;
            prev_product.Discount_Id = product.Discount_Id;

            await _productRepo.SaveChangesAsync();
            return prev_product;
        }
    }
}
