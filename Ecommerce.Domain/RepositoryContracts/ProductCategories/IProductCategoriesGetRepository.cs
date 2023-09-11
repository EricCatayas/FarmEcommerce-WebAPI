
namespace FarmEcommerce.Core.ServiceContracts.ProductCategories
{
    public interface IProductCategoriesGetRepository
    {
        Task<IEnumerable<Product_Category>> GetListAsync();
    }
}
