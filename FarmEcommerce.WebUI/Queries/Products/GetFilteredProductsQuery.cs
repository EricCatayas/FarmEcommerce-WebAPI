using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public class GetFilteredProductsQuery : ProductsFilterDTO, IRequest<IEnumerable<Product>> 
    {
        public GetFilteredProductsQuery(ProductsFilterDTO filterDTO)
        {
            Name = filterDTO.Name;
            Category_Id = filterDTO.Category_Id;
            Min_Price = filterDTO.Min_Price;
            Max_Price = filterDTO.Max_Price;
            Min_Rating_Value = filterDTO.Min_Rating_Value;
            Per_Qty_Type = filterDTO.Per_Qty_Type;
            Is_Negotiable = filterDTO.Is_Negotiable;
        }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductsGetService _productsGetService;

        public GetProductsQueryHandler(IProductsGetService productGetService)
        {
            _productsGetService = productGetService;
        }
        public Task<IEnumerable<Product>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            return _productsGetService.GetFilteredProducts(request);
        }
    }
}
