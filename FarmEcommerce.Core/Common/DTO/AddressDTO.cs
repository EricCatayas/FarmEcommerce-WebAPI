using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? Postal_Code { get; set; }
        public string Munipal { get; set; }
        public string Province { get; set; }
    }
}
