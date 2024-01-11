
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Extentions;

namespace FarmEcommerce.Core.Specifications.Products
{
    public sealed class ProductSpecification : SingleResultSpecification<Product>
    {
        public ProductSpecification(int product_Id) 
        {
            Query
                .Where(p => p.Id == product_Id)
                .IncludeAllEntities();
        }
    }
}
