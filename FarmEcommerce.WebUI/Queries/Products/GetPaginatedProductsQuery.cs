using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Specifications.Products;
using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public class GetPaginatedProductsQuery : PaginationFilter, IRequest<IEnumerable<Product>> 
    {
        public GetPaginatedProductsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    public class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, IEnumerable<Product>>
    {
        private readonly IReadRepository<Product> _productRepo;

        public GetPaginatedProductsQueryHandler(IReadRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<Product>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
        {
            var specification = new ProductsPaginatedListSpecification(request);
            var result = await _productRepo.ListAsync(specification);
            return result;
        }
    }
}
