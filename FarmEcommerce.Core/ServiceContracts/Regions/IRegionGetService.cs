
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Regions
{
    public interface IRegionGetService
    {
        public Task<IEnumerable<Region>> GetRegions();
    }
}
