using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class CartItemAddDTO
    {
        [Required]
        public int Cart_Id { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [MinLength(1)]
        public int Quantity { get; set; }
    }
}
