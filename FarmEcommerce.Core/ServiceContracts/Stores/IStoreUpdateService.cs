
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Stores
{
    public interface IStoreUpdateService
    {
        public Task<StoreDTO> UpdateAsync(StoreUpdateDTO store);
    }
}
