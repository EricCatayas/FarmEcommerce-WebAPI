using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.WebUI.ApiModels
{
    public class DiscountSummaryViewModel
    {
        public string? Name { get; set; }
        public float Discount_Rate { get; set; }
        public DateTime? End_Date { get; set; }
    }
}
