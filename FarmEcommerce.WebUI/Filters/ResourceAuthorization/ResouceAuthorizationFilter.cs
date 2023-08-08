using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.WebUI.Filters.ResourceAuthorization
{
    public abstract class ResourceAuthorizationFilter : IAsyncAuthorizationFilter
    {
        protected readonly IApplicationDbContext _dbContext;
        protected readonly IGetSignedInUserService _signedInUserService;
        protected readonly string Id_Name;
        protected readonly IBaseUserEntity? SignedInUser;
        protected int? Input_Id = null;

        public ResourceAuthorizationFilter(IApplicationDbContext dbContext, IGetSignedInUserService signedInUserService, string id_Name = "Id")
        {
            Id_Name = id_Name;
            _dbContext = dbContext;
            _signedInUserService = signedInUserService;
            SignedInUser = _signedInUserService.GetSignedInUser().Result;
        }
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
    }
}
 
