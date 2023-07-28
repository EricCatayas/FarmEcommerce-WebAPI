using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order_Line : BaseEntity
    {
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
