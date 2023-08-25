using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductDeleteService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <exception cref="DataNotFoundException"></exception>
        public Task DeleteAsync(int ProductId);
    }
}
