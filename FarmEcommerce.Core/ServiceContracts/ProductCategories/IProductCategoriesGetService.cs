
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.ProductCategories
{

    public interface IProductCategoriesGetService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAllAsync();
    }
}
