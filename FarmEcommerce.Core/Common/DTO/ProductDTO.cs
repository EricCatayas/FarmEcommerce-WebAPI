
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Extentions;

namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? Category_Id { get; private set; }
        public string? Category_Name { get; private set; }
        public string? Description { get; private set; }
        public bool Is_Negotiable { get; private set; }
        public decimal Price { get; private set; }
        public string Quantity_Unit { get; private set; }
        public int? Qty_In_Stock { get; private set; }
        public IEnumerable<ImageUploadDTO> Images { get; set; }
        public StoreDTO? Store { get; private set; }
        public DiscountDTO? Discount { get; private set; }

        private int Images_Id;

        public ProductDTO(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.Quantity_Unit = product.Quantity_Unit;
            this.Is_Negotiable = product.Is_Negotiable;
            this.Qty_In_Stock = product.Qty_In_Stock;
            this.Category_Id = product.Category?.Id;
            this.Category_Name = product.Category?.Category_Name;
            this.Images_Id = product.Images_Id;
            this.Images = product.Images != null && product.Images.Uploads != null ? product.Images.Uploads.ToImageUploadDTOs() : new List<ImageUploadDTO>();
            this.Store = product.Store != null ? new StoreDTO(product.Store) : null; // Null in Create and Update Services
            this.Discount = product.Discount != null ? new DiscountDTO(product.Discount) : null;
        }

        public int GetImagesID()
        {
            return this.Images_Id;
        }
    }

}
