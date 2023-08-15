using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public record GetMunicipalitiesFromProvinceQuery : IRequest<IEnumerable<Municipality>>
    {
        public int Province_Id { get; set; }
    }
    public class GetMunicipalitiesQueryHandler : IRequestHandler<GetMunicipalitiesFromProvinceQuery, IEnumerable<Municipality>>
    {
        private readonly IMunicipalitiesGetService _citiesGetService;

        public GetMunicipalitiesQueryHandler(IMunicipalitiesGetService citiesGetService)
        {
            _citiesGetService = citiesGetService;
        }
        public async Task<IEnumerable<Municipality>> Handle(GetMunicipalitiesFromProvinceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citiesGetService.GetByProvince(request.Province_Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
