using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }        
        public decimal Price { get; set; }
        public string Per_Qty_Type { get; set; }
        public bool Is_Negotiable { get; set; }
        public int? Qty_In_Stock { get; set; }
        public int? Rating_Value { get; set; }
        public virtual Store Store { get; set; }
        public int Store_Id { get; set; }
        public Images Images { get; set; }
        public int Images_Id { get; set; }
        public virtual Discount? Discount { get; set; }
        public int? Discount_Id { get; set; }
        public virtual Product_Category? Category { get; set; }
        public int? Category_Id { get; set; }
    }
}
