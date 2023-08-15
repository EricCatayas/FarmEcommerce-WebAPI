
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Addresses;
using FarmEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FarmEcommerce.Infrastructure.Repositories.Addresses
{
    public class ProvincesGetRepository : IProvincesGetRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public ProvincesGetRepository(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<Province>> GetAll()
        {
            IEnumerable<Province> provinces = new List<Province>();
            bool alreadyExists = _memoryCache.TryGetValue("Provinces_Data", out provinces);

            if(!alreadyExists)
            {
                provinces = await _dbContext.Provinces.OrderBy(x => x.Name).ToListAsync();
                var cacheEntry = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(22));
                _memoryCache.Set("Provinces_Data", provinces, cacheEntry);
            }
            return provinces;
        }
    }
}
