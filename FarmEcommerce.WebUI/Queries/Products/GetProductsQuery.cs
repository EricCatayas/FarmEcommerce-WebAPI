using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public class GetProductsQuery : ProductsFilterDTO, IRequest<IEnumerable<Product>> 
    {
        public GetProductsQuery(ProductsFilterDTO filterDTO)
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

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductGetService _productGetService;

        public GetProductsQueryHandler(IProductGetService productGetService)
        {
            _productGetService = productGetService;
        }
        public Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _productGetService.GetFilteredProducts(request);
        }
    }
}
