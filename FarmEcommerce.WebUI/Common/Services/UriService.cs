
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts;

namespace FarmEcommerce.Core.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPaginatedUri(PaginationFilter paginationFilter = null)
        {
            throw new NotImplementedException();
        }

        public Uri GetUri(int Id)
        {
            var modifiedUri = QueryHelpers.
            return new Uri(_baseUri + )
        }
    }
}
