using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Stores;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Stores
{
    public class StoreUpdateService : IStoreUpdateService
    {
        private readonly IGetSignedInUserService _signedInUserService;
        private readonly IRepository<Store> _storeRepo;        

        public StoreUpdateService(IGetSignedInUserService signedInUserService, IRepository<Store> storeRepo)
        {
            _signedInUserService = signedInUserService;
            _storeRepo = storeRepo;
        }
        public async Task<StoreDTO> UpdateAsync(StoreUpdateDTO store)
        {
            try
            {
                Store userStore = new()
                {
                    Id = store.Id,
                    Name = store.Name,
                    Description = store.Description,
                    Address_Id = store.Address_Id,
                    Established_Date = store.Established_Date
                };
                await _storeRepo.UpdateAsync(userStore);
                return new StoreDTO(userStore);
            }
            catch
            {
                throw;
            }
        }
    }
}
