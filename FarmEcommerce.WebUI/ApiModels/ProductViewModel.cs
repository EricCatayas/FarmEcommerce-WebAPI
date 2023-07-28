using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.ViewModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.WebUI.ApiModels
{
    public abstract class ProductViewModel
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public string Per_Qty_Type { get; set; }
        public bool Is_Negotiable { get; set; }
        public int Qty_In_Stock { get; set; }
        public string? Image_Url { get; set; }
        public string Category { get; set; }
        public int Store_Id { get; set; }
        public AddressDTO Address { get; set; }
    }
    public class ProductDetailViewModel : ProductViewModel, IImagesViewModel
    {
        public List<string>? Image_Urls { get; set; }
    }
}
