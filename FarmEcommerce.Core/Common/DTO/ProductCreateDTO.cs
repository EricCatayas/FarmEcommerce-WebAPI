using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.Common.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(150, ErrorMessage = "Product name must not be blank")]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [DefaultValue(true)]
        public bool Is_Negotiable { get; set; }
        [Required]
        public string Per_Qty_Type { get; set; }
        [Range(1, int.MaxValue)]
        public int? Qty_In_Stock { get; set; }
        public int? Category_Id { get; set; }
    }
}
