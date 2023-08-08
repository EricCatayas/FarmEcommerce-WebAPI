using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Cities;
using FarmEcommerce.Core.ServiceContracts.Regions;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public record GetRegionsQuery : IRequest<IEnumerable<Region>>{}
    public class GetRegionQueryHandler : IRequestHandler<GetRegionsQuery, IEnumerable<Region>>
    {
        private readonly IRegionGetService _regionGetService;

        public GetRegionQueryHandler(IRegionGetService regionGetService)
        {
            _regionGetService = regionGetService;
        }
        public async Task<IEnumerable<Region>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _regionGetService.GetRegions();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
