using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string Per_Qty_Type { get; set; }
        [Required]
        public bool Is_Negotiable { get; set; }
        [Range(1, int.MaxValue)]
        public int? Qty_In_Stock { get; set; }
        public int? Category_Id { get; set; }
        public int? Discount_Id { get; set; }
    }
}
