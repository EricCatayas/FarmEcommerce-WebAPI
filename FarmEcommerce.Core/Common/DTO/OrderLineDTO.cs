using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class OrderLineDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        public string? Product_Image_Url { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
