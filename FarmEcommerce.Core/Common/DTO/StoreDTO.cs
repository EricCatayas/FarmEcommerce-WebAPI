
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FarmEcommerce.Core.Common.DTO
{
    public class StoreDTO
    {
        public StoreDTO(Store store)
        {
            this.Name = store.Name;
            this.Description = store.Description;
            this.Store_Id = store.Id;
            this.Seller_Id = store.Owner_Id;
            this.Address_Id = store.Address_Id;
            this.Images_Id = store.Images.Id;
        }
        public int Store_Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Seller_Id { get;set; }
        public int? Address_Id { get; set; }
        public int? Images_Id { get; set; }
    }
}
