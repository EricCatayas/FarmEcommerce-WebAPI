
using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FarmEcommerce.Core.Common.DTO
{
    public class RegisterDTO : IBaseUserEntity
    {
        [AllowNull]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name can't be blank")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }    
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must only contain numerics")]
        [DataType(DataType.PhoneNumber)]
        public string? Contact_Num1 { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must only contain numerics")]
        [DataType(DataType.PhoneNumber)]
        public string? Contact_Num2 { get; set; }
        [Required(ErrorMessage = "Password can't be blank")]
        [MinLength(6, ErrorMessage = "Minimum length for password is 6 characters")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Invalid: Password does not match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        public int? Store_Id { get; set; }
        public int? Images_Id { get; set; }
        [AllowNull]
        public int User_Address_Id { get; set; }
    }
}
