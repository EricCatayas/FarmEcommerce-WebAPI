using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Products
{
    public record DeleteProductCommand : IRequest<Result> 
    {
        public int product_Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductDeleteService _productDeleteService;

        public DeleteProductCommandHandler(IProductDeleteService productDeleteService)
        {
            _productDeleteService = productDeleteService;
        }
        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productDeleteService.DeleteProduct(request.product_Id);

            }
            catch (Exception ex)
            {
                return Result.Failure(new List<string>() { ex.Message });
            }
        }
    }
}
