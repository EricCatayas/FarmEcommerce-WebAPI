
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts
{
    public interface IUriService
    {
        Uri GetUri(int Id);
        Uri GetPaginatedUri(PaginationFilter paginationFilter = null);
    }
}
