
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.Common.Extentions
{
    public static class ProductExtention
    {
        public static Product ToProduct(this ProductCreateDTO product)
        {
            return new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Is_Negotiable = product.Is_Negotiable,
                Quantity_Unit = product.Quantity_Unit,
                Qty_In_Stock = product.Qty_In_Stock,
                Category_Id = product.Category_Id,
            };
        }
    }
}
