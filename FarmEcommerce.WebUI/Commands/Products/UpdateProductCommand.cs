using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Products
{
    public class UpdateProductCommand : ProductUpdateDTO, IRequest<Result> 
    {
        public UpdateProductCommand(ProductUpdateDTO product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Is_Negotiable = product.Is_Negotiable;
            Quantity_Unit = product.Quantity_Unit;
            Qty_In_Stock = product.Qty_In_Stock;
            Category_Id = product.Category_Id;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductUpdateService _productUpdateService;

        public UpdateProductCommandHandler(IProductUpdateService productUpdateService)
        {
            _productUpdateService = productUpdateService;
        }
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _productUpdateService.UpdateProduct(request);
                return Result.Success();
            }
            catch
            {
                throw;
            }

        }
    }
}
