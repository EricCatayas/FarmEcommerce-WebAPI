using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public record GetProductQuery : IRequest<ProductDTO>
    {
        public int product_Id { get; set; }
    }
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductGetService _productGetService;

        public GetProductHandler(IProductGetService productGetService)
        {
            _productGetService = productGetService;
        }
        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productGetService.GetProduct(request.product_Id);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
