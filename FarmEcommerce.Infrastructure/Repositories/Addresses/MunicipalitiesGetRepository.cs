
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Addresses;
using FarmEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FarmEcommerce.Infrastructure.Repositories.Addresses
{
    public class MunicipalitiesGetRepository : IMunicipalitiesGetRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public MunicipalitiesGetRepository(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<Municipality>> GetAsync(int? province_Id)
        {
            IEnumerable<Municipality> municipalities = new List<Municipality>();
            bool alreadyExists = false;
            if( province_Id != null )
            {
                alreadyExists = _memoryCache.TryGetValue($"Municipalities_From_Province{province_Id}", out municipalities);

                if (!alreadyExists)
                {
                    municipalities = await _dbContext.Municipalities.Where(x => x.Province_Id == province_Id).OrderBy(x => x.Name).ToListAsync();
                    var cacheEntry = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(22));
                    _memoryCache.Set($"Municipalities_From_Province{province_Id}", municipalities, cacheEntry);
                }
            }
            else
            {
                alreadyExists = _memoryCache.TryGetValue("Municipalities_Data", out municipalities);

                if (!alreadyExists)
                {
                    municipalities = await _dbContext.Municipalities.OrderBy(x => x.Name).ToListAsync();
                    var cacheEntry = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(22));
                    _memoryCache.Set("Municipalities_Data", municipalities, cacheEntry);
                }
            }
            return municipalities; 
        }
    }
}
