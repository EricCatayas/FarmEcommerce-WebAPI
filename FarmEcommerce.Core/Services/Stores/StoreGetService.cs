
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Stores
{
    public class StoreGetService : IStoreGetService
    {
        private readonly IApplicationDbContext dbContext;

        public StoreGetService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Store> GetById(int store_id)
        {
            var store = await dbContext.Stores.Include(a => a.Images).Include(a => a.Address).FirstOrDefaultAsync(a => a.Id == store_id);
            if(store == null)
            {
                throw new DataNotFoundException(typeof(Store), store_id);
            }
            return store;
        }
    }
}
