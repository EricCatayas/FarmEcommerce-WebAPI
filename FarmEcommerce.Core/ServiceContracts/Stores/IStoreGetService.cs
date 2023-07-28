
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.ServiceContracts.Stores
{
    public interface IStoreGetService
    {
        public Task<Store> GetById(int  store_id);
    }
}
