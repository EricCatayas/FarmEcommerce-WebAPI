using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Shopping_Cart
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
    }
}
