using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmEcommerce.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IBaseUserEntity
    {
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public override string? UserName { get => base.UserName; set => base.UserName = value; }
        public override string? Email { get => base.Email; set => base.Email = value; }
        [NotMapped]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public string? Contact_Num1 { get; set; }
        public string? Contact_Num2 { get; set; }
        public Images? Images { get; set; }
        public int? Images_Id { get; set; }
        public int User_Address_Id { get; set; }
        public int? Store_Id { get; set; }
    }
}
