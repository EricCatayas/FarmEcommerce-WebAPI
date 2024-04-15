
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Extentions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Products;
using FarmEcommerce.Core.Specifications.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Products
{
    public class FilteredProductsGetService : IFilteredProductsGetService
    {
        private readonly IReadRepository<Product> _productRepo;

        public FilteredProductsGetService(IReadRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<ProductDTO>> GetFilteredProducts(ProductsFilterDTO filterDTO)
        {
            var spec = new ProductsFilteredSpecification(filterDTO);
            var result = await _productRepo.ListAsync(spec);
            return result.Select(p => new ProductDTO(p));
        }
    }
}
namespace FarmEcommerce.Core.Services.Products.V2
{
    // TODO: Fix 500 SQL Time Exceeded
    public class FilteredProductsGetService : IFilteredProductsGetService
    {
        private readonly IApplicationDbContext _dbContext;

        public FilteredProductsGetService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ProductDTO>> GetFilteredProducts(ProductsFilterDTO filterDTO)
        {
            IQueryable<Product> query = _dbContext.Products;

            if (filterDTO.Store_Id != null)
                query = query.Where(p => p.Store_Id == filterDTO.Store_Id);
            
            if (filterDTO.Category_Id != null)
                query = query.Where(p => p.Category_Id == filterDTO.Category_Id);

            if (!string.IsNullOrEmpty(filterDTO.Name))
            {
                string nameFilter = filterDTO.Name.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(nameFilter));
            }

            if (filterDTO.Max_Price != null)
                query = query.Where(p => p.Price <= filterDTO.Max_Price);

            if (filterDTO.Min_Price != null)
                query = query.Where(p => p.Price >= filterDTO.Min_Price);

            if (filterDTO.Is_Negotiable != null)
                query = query.Where(p => p.Is_Negotiable == filterDTO.Is_Negotiable);

            var result = await query.IncludeAllEntities().ToListAsync();

            return result.Select(p => new ProductDTO(p));
        }
    }
}
