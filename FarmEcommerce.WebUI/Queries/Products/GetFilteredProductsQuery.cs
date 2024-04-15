using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public class GetFilteredProductsQuery : ProductsFilterDTO, IRequest<IEnumerable<ProductDTO>> 
    {
        public GetFilteredProductsQuery(ProductsFilterDTO filterDTO)
        {
            Name = filterDTO.Name;
            Category_Id = filterDTO.Category_Id;
            Min_Price = filterDTO.Min_Price;
            Max_Price = filterDTO.Max_Price;
            Min_Rating_Value = filterDTO.Min_Rating_Value;
            Quantity_Unit = filterDTO.Quantity_Unit;
            Is_Negotiable = filterDTO.Is_Negotiable;
        }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IFilteredProductsGetService _filteredProductsGetService;

        public GetProductsQueryHandler(IFilteredProductsGetService productGetService)
        {
            _filteredProductsGetService = productGetService;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _filteredProductsGetService.GetFilteredProducts(request);

            return products;
        }
    }
}
