
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts;
using FarmEcommerce.WebUI.Common.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace FarmEcommerce.WebUI.Common.Services
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
            var uri = new Uri(_baseUri);
            if (paginationFilter == null)

                return uri;
            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", paginationFilter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageSize", paginationFilter.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetUri(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
