using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Filters.ResourceAuthorization
{
    /// <summary>
    /// An <see cref="IAsyncAuthorizationFilter"/> that checks whether a request is signed in and has ownership of a resource (i.e., product).
    /// </summary>
    public class ProductAuthorizeFilter : ResourceAuthorizationFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAuthorizeFilter"/> class.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        /// <param name="signedInUserService">Service providing signed-in user information.</param>
        public ProductAuthorizeFilter(IApplicationDbContext dbContext, IGetSignedInUserService signedInUserService) : base(dbContext, signedInUserService) { }
        /// <summary>
        /// Determines whether the current user is authorized to access the product resource.
        /// </summary>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation. The result is <c>true</c> if authorized; otherwise, <c>false</c>.</returns>
        public override async Task<bool> IsAuthorized()
        {
            return (SignedInUser != null && Input_Id != null && await _dbContext.Products.AnyAsync(a => a.Id == Input_Id && a.Store_Id == SignedInUser.Store_Id));
        }
    }
    
}
