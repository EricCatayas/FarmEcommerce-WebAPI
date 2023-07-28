using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.RepositoryContracts.Addresses
{
    public interface IAddressGetRepository
    {
        public Task<Address> GetAddressById(int id);
        public Task<Address> GetAddressByUserId(int userId);
    }
}
