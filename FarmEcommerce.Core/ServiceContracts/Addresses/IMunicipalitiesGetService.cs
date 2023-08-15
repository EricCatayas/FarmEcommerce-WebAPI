using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.ServiceContracts.Addresses
{
    public interface IMunicipalitiesGetService
    {
        public Task<IEnumerable<Municipality>> GetAllAsync();
        public Task<IEnumerable<Municipality>> GetByProvince(int province_Id);
    }
}
