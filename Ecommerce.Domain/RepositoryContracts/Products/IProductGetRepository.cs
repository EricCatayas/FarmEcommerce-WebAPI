
using System.Linq.Expressions;
using System;

namespace Ecommerce.Domain.RepositoryContracts.Products
{
    public interface IProductGetRepository
    {
        public Task<Product> GetAsync(int id);
        public Task<Product> GetListAsync(Expression<Func<Product, bool>> predicate);
    }
}
