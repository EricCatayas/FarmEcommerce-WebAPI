
namespace FarmEcommerce.Core.ServiceContracts.ProductCategories
{
    public interface IProductCategoriesGetService
    {
        Task<IEnumerable<Product_Category>> GetAllAsync();
    }
}
