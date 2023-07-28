using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class OrderDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public IEnumerable<OrderLineDTO> Order_Lines { get; set; }
        [Required]
        public DateTime Order_Date { get; set; }
        [Required]
        public AddressDTO Shipping_Address { get; set; }
        [Required]
        public string Shipping_Method { get; set; }
        [Required]
        public string Payment_Method { get; set; }
        [Required]
        public decimal Order_Total { get; set; }
        public string? Order_Status { get; set; }
    }
}
