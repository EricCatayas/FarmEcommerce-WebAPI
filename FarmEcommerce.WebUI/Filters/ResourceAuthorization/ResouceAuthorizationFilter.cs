using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Filters.ResourceAuthorization
{
    /// <summary>
    /// An <see cref="IAsyncAuthorizationFilter"/> base class that checks whether a request is authorized to access a resource.
    /// </summary>
    public abstract class ResourceAuthorizationFilter : IAsyncAuthorizationFilter
    {
        protected readonly IApplicationDbContext _dbContext;
        protected readonly IGetSignedInUserService _signedInUserService;
        protected readonly string Id_Name;
        protected readonly IBaseUserEntity? SignedInUser;
        protected int? Input_Id = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAuthorizeFilter"/> class.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        /// <param name="signedInUserService">Service providing signed-in user information.</param>
        /// <param name="id_Name">The unique identifier property name of the resource.</param>
        public ResourceAuthorizationFilter(IApplicationDbContext dbContext, IGetSignedInUserService signedInUserService, string id_Name = "Id")
        {
            Id_Name = id_Name;
            _dbContext = dbContext;
            _signedInUserService = signedInUserService;
            SignedInUser = GetSignedInUserFromRequest().Result;
        }
        /// <summary>
        /// Determines whether the current user is authorized to access the resource.
        /// </summary>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation. The result is <c>true</c> if authorized; otherwise, <c>false</c>.</returns>
        public abstract Task<bool> IsAuthorized();
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            int? input_Id = null;


            if (context.HttpContext.Request.Form.ContainsKey(Id_Name))
            {
                input_Id = Convert.ToInt32(context.HttpContext.Request.Form[Id_Name].ToString());
            }
            else if (context.HttpContext.Request.Query.ContainsKey(Id_Name))
            {
                input_Id = Convert.ToInt32(context.HttpContext.Request.Query[Id_Name].ToString());
            }
            else
            {
                context.Result = new BadRequestObjectResult("Id is not included.");
            }


            if (!await IsAuthorized())
            {
                context.Result = new UnauthorizedObjectResult("Client is unathorized to access resource.");
            }
        }
        private async Task<IBaseUserEntity?> GetSignedInUserFromRequest()
        {
            try
            {
                return await _signedInUserService.GetSignedInUser();
            }
            catch
            {
                return null;
            }
        }
    }
}
 
