
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.RepositoryContracts.Products;
using FarmEcommerce.Infrastructure.Data;

namespace FarmEcommerce.Infrastructure.Repositories.Products
{
    public class ProductCreateRepository : IProductCreateRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
            return product;
        }
    }
}
