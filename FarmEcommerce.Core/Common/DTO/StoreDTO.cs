
using System.ComponentModel.DataAnnotations;

namespace FarmEcommerce.Core.Common.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Seller_Id { get;set; }
        public int Address_Id { get; set; }
        public string? Image_Url { get; set; }
        public int? Store_Id { get; set; }
    }
}
