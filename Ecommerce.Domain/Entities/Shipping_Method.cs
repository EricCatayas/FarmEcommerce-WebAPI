using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Shipping_Method : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
