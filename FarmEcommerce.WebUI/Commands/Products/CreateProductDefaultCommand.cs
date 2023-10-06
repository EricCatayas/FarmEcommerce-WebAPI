
using Ecommerce.Domain.RepositoryContracts.Products;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.ServiceContracts.Products;
using MediatR;

namespace FarmEcommerce.Core.Commands.Products
{
    public class CreateProductDefaultCommand : ProductCreateDTO, IRequest<Result> 
    {
        public CreateProductDefaultCommand(ProductCreateDTO product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Is_Negotiable = product.Is_Negotiable;
            Per_Qty_Type = product.Per_Qty_Type;
            Qty_In_Stock = product.Qty_In_Stock;
            Category_Id = product.Category_Id;
        }
    }

    public class CreateProductDefaultCommandHandler : IRequestHandler<CreateProductDefaultCommand, Result>
    {
        private readonly IProductCreateService _createService;

        public CreateProductDefaultCommandHandler(IProductCreateService productCreateService)
        {
            _createService = productCreateService;
        }
        public async Task<Result> Handle(CreateProductDefaultCommand request, CancellationToken cancellationToken)
        {
            if(ValidationHelper.ModelInValid(request, out string errorMessage))
            {
                return Result.Failure(new List<string>() { errorMessage });
            }

            try
            {
                await _createService.AddAsync(request);
                return Result.Success();
            }
            catch
            {
                throw;
            }
        }
    }
}
