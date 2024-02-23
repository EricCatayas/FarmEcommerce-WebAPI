
using System.ComponentModel.DataAnnotations;

namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductsFilterDTO
    {
        public string? Name { get; set; }
        [Range(1, int.MaxValue)]
        public decimal? Min_Price { get; set; }
        [Range(1, int.MaxValue)]
        public decimal? Max_Price { get; set; }
        public int? Store_Id { get; set; }
        public string? Quantity_Unit { get; set; }
        public bool? Is_Negotiable { get; set; }
        public int? Min_Rating_Value { get; set; }
        public int? Category_Id { get; set; }
    }    
}
