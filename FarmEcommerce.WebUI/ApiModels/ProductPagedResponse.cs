using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.WebUI.ApiModels
{
    public class ProductPagedResponse : PagedResponse<ProductDTO>
    {
        public IEnumerable<ProductDTO> Items
        {
            get
            {
                return Data;
            }
            private set {}
        }
    }
}
