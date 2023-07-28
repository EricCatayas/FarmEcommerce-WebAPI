using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Shopping_Cart_Item : BaseEntity
    {
        public int Cart_Id { get; set; }
        public int Product_Id { get; set; }
        [MinLength(1)]
        public int Quantity { get; set; }

    }
}
