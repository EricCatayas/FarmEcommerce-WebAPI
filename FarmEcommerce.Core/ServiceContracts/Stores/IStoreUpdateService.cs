
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Stores
{
    public interface IStoreUpdateService
    {
        public Task<Store> UpdateAsync(StoreUpdateDTO store);
    }
}
