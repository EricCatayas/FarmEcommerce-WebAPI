using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class User_Payment_Method : BaseEntity
    {
        public int UserId { get; set; }
        public string Payment_Type { get; set; }
        public string Provider { get; set; }
        public int Account_Number { get; set; }
        public DateTime Expiry_Date { get; set; }
        public bool IsDefault { get; set; }
    }
}
