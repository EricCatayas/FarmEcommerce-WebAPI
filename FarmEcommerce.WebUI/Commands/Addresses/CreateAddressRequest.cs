using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.WebUI.ApiModels;
using MediatR;

namespace FarmEcommerce.WebUI.Commands.Addresses
{
    public class CreateAddressRequest : AddressCreateDTO, IRequest<Address>
    {
    }
    public class CreateAddressRequestHandler : IRequestHandler<CreateAddressRequest, Address>
    {
        private readonly IAddressCreateService _addressCreateService;

        public CreateAddressRequestHandler(IAddressCreateService addressCreateService)
        {
            _addressCreateService = addressCreateService;
        }
        public async Task<Address> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressCreateService.CreateAsync(request);
            }
            catch
            {
                throw;
            }
        }
    }
}
