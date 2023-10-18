
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductDTO
    {
        public ProductDTO(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.Per_Qty_Type = product.Per_Qty_Type;
            this.Images_Id = product.Images_Id;
            this.Images = product.Images.Uploads;
            this.Discount = product.Discount != null ? new DiscountDTO(product.Discount) : null;
            this.Store = new StoreDTO(product.Store);
            this.Category_Id = product.Category?.Id;
            this.Category_Name = product.Category?.Category_Name;
        }
        public int Id{ get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public string Per_Qty_Type { get; private set; }
        public bool Is_Negotiable { get; private set; }
        public int? Qty_In_Stock { get; private set; }
        public int? Rating_Value { get; private set; }
        public int? Category_Id { get; private set; }
        public string? Category_Name { get; private set; }
        private int Images_Id;
        public IEnumerable<Image_Upload>? Images { get; set; }
        public StoreDTO Store { get; private set; }
        public DiscountDTO? Discount { get; private set; }
        public int GetImagesID()
        {
            return this.Images_Id;
        }
    }
}
