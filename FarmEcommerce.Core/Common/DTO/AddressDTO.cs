using Ecommerce.Domain.Entities;
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
        public string? Barangay { get; set; }
        public string Municipality { get; set; }
        public string? Postal_Code { get; set; }
        public string Province { get; set; }
        public string? Street { get; set; }
        public AddressDTO(Address address)
        {
            this.Id = address.Id; 
            this.Street = address.Street;
            this.Barangay = address.Barangay;
            this.Postal_Code = address.Postal_Code;
            this.Municipality = address.GetMunicipalityName();
            this.Province = address.GetProvinceName();
        }
    }
}
