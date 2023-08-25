using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.Core.Services.Addresses;
using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public record GetUserAddressListQuery : IRequest<IEnumerable<Address>> { }

    public class GetUserAddressListQueryHandler : IRequestHandler<GetUserAddressListQuery, IEnumerable<Address>>
    {
        private readonly IAddressGetService _addressGetService;
        private readonly IGetSignedInUserService _signedInUserService;

        public GetUserAddressListQueryHandler(IAddressGetService addressGetService, IGetSignedInUserService signedInUserService)
        {
            _addressGetService = addressGetService;
            _signedInUserService = signedInUserService;
        }
        public async Task<IEnumerable<Address>> Handle(GetUserAddressListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _signedInUserService.GetSignedInUser();

                if (user == null)
                    throw new UnathorizedRequestException();
                return await _addressGetService.GetUserAddressList(user.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}