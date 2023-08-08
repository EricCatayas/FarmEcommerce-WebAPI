using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Products
{
    public record GetProductQuery : IRequest<Product>
    {
        public int product_Id { get; set; }
    }
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductGetService _productGetService;

        public GetProductHandler(IProductGetService productGetService)
        {
            _productGetService = productGetService;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productGetService.GetProduct(request.product_Id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
