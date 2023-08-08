using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.ServiceContracts.Cities;
using MediatR;

namespace FarmEcommerce.WebUI.Queries.Addresses
{
    public record GetCitiesFromRegionQuery : IRequest<IEnumerable<City>>
    {
        public int? Region_Id { get; set; }
    }
    public class GetCitiesFromRegionQueryHandler : IRequestHandler<GetCitiesFromRegionQuery, IEnumerable<City>>
    {
        private readonly ICitiesGetService _citiesGetService;

        public GetCitiesFromRegionQueryHandler(ICitiesGetService citiesGetService)
        {
            _citiesGetService = citiesGetService;
        }
        public async Task<IEnumerable<City>> Handle(GetCitiesFromRegionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _citiesGetService.GetCities();
                return request.Region_Id != null ? result.Where(x => x.Region_Id ==  request.Region_Id).ToList() : result;
            }
            catch
            {
                throw;
            }
        }
    }
}
