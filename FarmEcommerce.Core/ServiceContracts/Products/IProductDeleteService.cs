using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Products
{
    public interface IProductDeleteService
    {
        public Task<Result> DeleteProduct(int ProductId);
    }
}
