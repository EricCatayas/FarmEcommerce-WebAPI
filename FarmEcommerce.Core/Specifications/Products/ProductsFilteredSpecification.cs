
using Ardalis.Specification;
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using System.Linq.Expressions;

namespace FarmEcommerce.Core.Specifications.Products
{
    public class ProductsFilteredSpecification : Specification<Product>
    {
        public ProductsFilteredSpecification(ProductsFilterDTO filterDTO) 
        {
            if(filterDTO.Store_Id != null)
                Query.Where(p => p.Store_Id == filterDTO.Store_Id); 
            
            if(!string.IsNullOrEmpty(filterDTO.Name)) 
                Query.Where(p => p.Name.Contains(filterDTO.Name, StringComparison.OrdinalIgnoreCase)); 
            
            if(filterDTO.Is_Negotiable != null) 
                Query.Where(p => p.Is_Negotiable == filterDTO.Is_Negotiable);
            
            if(filterDTO.Max_Price != null) 
                Query.Where(p => p.Price <= filterDTO.Max_Price); 
            
            if(filterDTO.Min_Price != null) 
                Query.Where(p => p.Price >= filterDTO.Min_Price); 
            
            if(filterDTO.Category_Id != null) 
                Query.Where(p => p.Category_Id == filterDTO.Category_Id);


            Query.IncludeAllEntities();
        }
    }
}
