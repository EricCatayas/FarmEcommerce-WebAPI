
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using System.Linq.Expressions;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductGetService
    {
        public Task<Product> GetProduct(int product_id);        
    }
}
