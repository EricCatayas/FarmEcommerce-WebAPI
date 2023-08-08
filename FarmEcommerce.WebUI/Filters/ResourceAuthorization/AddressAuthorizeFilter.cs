using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Filters.ResourceAuthorization
{
    public class AddressAuthorizeFilter : ResourceAuthorizationFilter
    {
        public AddressAuthorizeFilter(IApplicationDbContext dbContext, IGetSignedInUserService signedInUserService) : base(dbContext, signedInUserService) { }        
        public override async Task<bool> IsAuthorized()
        {
            return (SignedInUser != null && Input_Id != null && await _dbContext.User_Addresses.AnyAsync(a => a.Id == Input_Id && a.User_Id == SignedInUser.Id));
        }
    }
}
