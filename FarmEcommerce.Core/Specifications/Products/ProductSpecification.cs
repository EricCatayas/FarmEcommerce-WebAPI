
using Ardalis.Specification;
using Ecommerce.Domain.Entities;

namespace FarmEcommerce.Core.Specifications.Products
{
    public sealed class ProductSpecification : SingleResultSpecification<Product>
    {
        public ProductSpecification(int item_Id) 
        {
            Query
                .Where(p => p.Id == item_Id)
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Store)
                .Include(p => p.Discount);
        }
    }
}
