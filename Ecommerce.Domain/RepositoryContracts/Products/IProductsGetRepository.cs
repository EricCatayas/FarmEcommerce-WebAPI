
using System.Linq.Expressions;
using System;

namespace Ecommerce.Domain.RepositoryContracts.Products
{
    public interface IProductsGetRepository
    {
        public Task<IEnumerable<Product>> GetAsync(int product_Id);
        // public Task<Product> GetListAsync(Expression<Func<Product, bool>> predicate);
    }
}
