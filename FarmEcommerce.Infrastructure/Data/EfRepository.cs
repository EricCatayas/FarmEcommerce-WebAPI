using Ardalis.Specification.EntityFrameworkCore;
using FarmEcommerce.Infrastructure.Data;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
