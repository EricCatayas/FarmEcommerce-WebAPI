using Ecommerce.Domain.Common;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Security.Claims;

namespace FarmEcommerce.Infrastructure.Services
{
    /// <summary>
    /// Note that in order to use the HttpContext class in a service, you need to register the IHttpContextAccessor interface with the dependency injection system.
    /// </summary>
    public class GetSignedInUserService : IGetSignedInUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Guid? UserId { get; set; }
        public GetSignedInUserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IBaseUserEntity?> GetSignedInUser()
        {
            if (UserId == null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                    return null;
                var userId = userIdClaim?.Value;
                UserId = Guid.Parse(userId);
            }
            //return await _userManager.Users.Include(a => a.Store).FirstOrDefaultAsync(x => x.Id == UserId);
            return await _userManager.FindByIdAsync(UserId.ToString());
        }
    }
}
