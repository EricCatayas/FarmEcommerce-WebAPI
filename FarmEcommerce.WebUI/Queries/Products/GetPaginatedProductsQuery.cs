using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public class GetPaginatedProductsQuery : PaginationFilter, IRequest<IEnumerable<ProductDTO>> 
    {
        public GetPaginatedProductsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    public class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IPaginatedProductsGetService _paginatedProductsGetService;

        public GetPaginatedProductsQueryHandler(IPaginatedProductsGetService paginatedProductsGetService)
        {
            _paginatedProductsGetService = paginatedProductsGetService;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paginatedProductsGetService.GetAsync(request);            
            }
            catch
            {
                throw;
            }
        }
    }
}
