using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(1, 100)]
        public float Discount_Rate { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
    }
}
