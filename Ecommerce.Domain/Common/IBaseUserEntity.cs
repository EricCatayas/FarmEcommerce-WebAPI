using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Common
{
    public interface IBaseUserEntity
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Contact_Num1 { get; set; }
        public string? Contact_Num2 { get; set; }
        public int? Store_Id { get; set; }
        public int? Images_Id { get; set; }
        public int User_Address_Id { get; set; }
    }
}
