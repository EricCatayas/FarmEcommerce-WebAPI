using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.RepositoryContracts.Addresses
{
    public interface IAddressCreateRepository
    {
        public Task<Address> CreateAsync(Address address);
    }
}
