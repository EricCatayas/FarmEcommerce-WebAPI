using Ecommerce.Domain.Entities;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public class GetAddressQuery : IRequest<Address>
    {
        public int Address_Id { get; set; }
    }
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
    {
        public Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
