
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using System.Linq.Expressions;

namespace FarmEcommerce.Core.Specifications.Products
{
    public sealed class ProductsFilteredSpecification : Specification<Product>
    {
        public ProductsFilteredSpecification(ProductsFilterDTO filterDTO) 
        {
            if(filterDTO.Name != null) 
            {
                Query.Where(p => p.Name.Contains(filterDTO.Name, StringComparison.OrdinalIgnoreCase)); 
            }
            if(filterDTO.Is_Negotiable != null) 
            {
                Query.Where(p => p.Is_Negotiable == filterDTO.Is_Negotiable);
            }
            if(filterDTO.Max_Price != null) 
            {
                Query.Where(p => p.Price <= filterDTO.Max_Price); 
            }
            if(filterDTO.Min_Price != null) 
            {
                Query.Where(p => p.Price >= filterDTO.Min_Price); 
            }
            if(filterDTO.Min_Rating_Value != null) 
            {
                Query.Where(p => p.Rating_Value >= filterDTO.Min_Rating_Value); 
            }
            if(filterDTO.Category_Id != null) 
            {
                Query.Where(p => p.Category_Id == filterDTO.Category_Id); 
            }

            Query
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Store)
                .Include(p => p.Discount);
        }
    }
}
