using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Addresses
{
    public class UpdateAddressRequest : AddressUpdateDTO, IRequest<Result>
    {
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateAddressRequest, Result>
    {
        private readonly IAddressUpdateService _addressUpdateService;

        public UpdateProductCommandHandler(IAddressUpdateService addressUpdateService)
        {
            _addressUpdateService = addressUpdateService;
        }
        public async Task<Result> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressUpdateService.UpdateAsync(request);
            }
            catch
            {
                throw;
            }
        }
    }
}
