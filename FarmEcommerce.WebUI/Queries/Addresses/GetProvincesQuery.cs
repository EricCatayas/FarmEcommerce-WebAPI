using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public record GetProvincesQuery : IRequest<IEnumerable<Province>>{}
    public class GetRegionQueryHandler : IRequestHandler<GetProvincesQuery, IEnumerable<Province>>
    {
        private readonly IProvincesGetService _provincesGetService;

        public GetRegionQueryHandler(IProvincesGetService regionGetService)
        {
            _provincesGetService = regionGetService;
        }
        public async Task<IEnumerable<Province>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _provincesGetService.GetProvinces();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
