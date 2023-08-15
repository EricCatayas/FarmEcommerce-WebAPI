using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class AddressUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(500)]
        public string? Street { get; set; }
        [Required]
        [StringLength(100)]
        public string Barangay { get; set; }
        [StringLength(10)]
        public string? Postal_Code { get; set; }
        [Required]
        public int Municipality_Id { get; set; }
    }
}
