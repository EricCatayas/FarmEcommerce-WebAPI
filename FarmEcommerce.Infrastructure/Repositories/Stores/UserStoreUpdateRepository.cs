using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Stores;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmEcommerce.Infrastructure.Repositories.Stores
{
    public class UserStoreUpdateRepository : IStoreUpdateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserStoreUpdateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Store> UpdateAsync(Store store)
        {
            _dbContext.Stores.Update(store);
            await _dbContext.SaveChangesAsync();
            return store;
        }
    }
}
