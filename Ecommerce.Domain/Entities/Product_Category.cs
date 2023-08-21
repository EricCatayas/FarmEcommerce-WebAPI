using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product_Category : BaseEntity
    {
        public virtual Product_Category? Parent_Category { get; set; }
        public int? Parent_Category_Id { get; set; }
        public string Category_Name { get; set; }
        public string? Image_Url { get; set; }
    }
}
