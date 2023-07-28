using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.WebUI.ApiModels
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public IEnumerable<CartItemDTO> Items { get; set; }
        public decimal Total { get; set; }
    }
    public class CartItemDTO
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
    }

}
