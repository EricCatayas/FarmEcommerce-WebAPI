using FarmEcommerce.Core.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.ServiceContracts.Cities
{
    public interface ICitiesGetService
    {
        public Task<List<CityDTO>> GetCities();
    }
}
