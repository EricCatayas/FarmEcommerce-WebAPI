
namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public int Parent_Category_Id { get; set; }
        public IEnumerable<ProductCategoryDTO> SubCategories { get; set; }
        public string? Image_Url { get; set; }
    }
}
