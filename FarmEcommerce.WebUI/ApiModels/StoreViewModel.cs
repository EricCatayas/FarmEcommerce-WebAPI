
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.WebUI.ViewModelContracts;

namespace FarmEcommerce.WebUI.ApiModels
{
    public class StoreViewModel : IImagesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Established_Date { get; set; }
        public Address Address { get; set; }
        public UserDTO Owner { get; set; }
        public List<string>? Image_Urls { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
