
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.WebUI.Common.Interfaces
{
    public interface IUriService
    {
        Uri GetUri(int Id);
        Uri GetPaginatedUri(PaginationFilter paginationFilter = null);
    }
}
