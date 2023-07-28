
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Regions
{
    public interface IRegionGetService
    {
        public Task<List<Region>> GetRegions();
    }
}
