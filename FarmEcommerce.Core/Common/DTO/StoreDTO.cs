
using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FarmEcommerce.Core.Common.DTO
{
    public class StoreDTO
    {
        public StoreDTO(Store store)
        {           
            this.Store_Id = store.Id;
            this.Name = store.Name;
            this.Description = store.Description;
            this.Address = new AddressDTO(store.Address);
            this.Seller_Id = store.Owner_Id;
            this.Images_Id = store.Images?.Id;
        }
        public int Store_Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime? Established_Date { get; private set; }
        public Guid Seller_Id { get; private set; }
        public AddressDTO Address { get; private set; }
        public int? Images_Id { get; private set; }
    }
}

