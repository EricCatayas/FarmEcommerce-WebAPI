using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string? Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must not be less than 6 characters")]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public int? Images_Id { get; set; }
        public string? Street { get; set; }
        public string? Postal_Code { get; set; }
        [Required]
        public int? Barangay_Id { get; set; }
        [Required]
        public int? City_Id { get; set; }
    }
}
