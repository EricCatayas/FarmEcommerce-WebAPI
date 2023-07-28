using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int User_Id { get; set; }
        public DateTime Order_Date { get; set; } 
        public Address? Address { get; set; }
        public int? Shipping_Address_Id { get; set; }
        public Shipping_Method? Shipping_Method { get; set; }
        public int? Shipping_Method_Id { get; set; }
        public User_Payment_Method? Payment_Method { get; set; }
        public int? Payment_Method_Id { get; set; }
        public decimal Order_Total { get; set; }
        public IEnumerable<Order_Line> Lines { get; set; }
        public Order_Status? Status { get; set; }
        public int? Order_Status_Id { get; set; }

    }
}
