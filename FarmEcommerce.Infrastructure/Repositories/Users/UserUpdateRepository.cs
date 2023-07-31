
using Ecommerce.Domain.Common;
using Ecommerce.Domain.RepositoryContracts.Users;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Data;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FarmEcommerce.Infrastructure.Repositories.Users
{
    [Obsolete]
    public class UserUpdateRepository : IUserUpdateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserUpdateRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IBaseUserEntity> UpdateAsync(IBaseUserEntity user)
        {
            try
            {
                var appUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                appUser.UserName = user.UserName;
                appUser.Email = user.Email;
                appUser.Contact_Num1 = user.Contact_Num1;
                appUser.Contact_Num2 = user.Contact_Num2;
            
                await _userManager.UpdateAsync(appUser);
                return appUser;
            } catch (Exception ex)
            {
                throw new RequestDeniedException();
            }
        }
    }
}
