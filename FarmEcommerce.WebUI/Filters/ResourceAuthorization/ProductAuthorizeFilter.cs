using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Filters.ResourceAuthorization
{
    public class ProductAuthorizeFilter : ResourceAuthorizationFilter
    {
        public ProductAuthorizeFilter(IApplicationDbContext dbContext, IGetSignedInUserService signedInUserService) : base(dbContext, signedInUserService) { }
        public override async Task<bool> IsAuthorized()
        {
            return (SignedInUser != null && Input_Id != null && await _dbContext.Products.AnyAsync(a => a.Id == Input_Id && a.Store_Id == SignedInUser.Store_Id));
        }
    }
    
}
