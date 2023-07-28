using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class User_Review : BaseEntity 
    {
        public int User_Id { get; set; }
        public int Ordered_Product_Id { get; set; }
        [MinLength(1)]
        [MaxLength(5)]
        public int Rating_Value { get; set; }
        public string? Comment { get; set; }
    }
}
