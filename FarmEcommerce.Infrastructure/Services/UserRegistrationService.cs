
using Ecommerce.Domain.Enums;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FarmEcommerce.Infrastructure.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserRegistrationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Result> CreateUserAsync(RegisterDTO user)
        {
            var appUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Contact_Num1 = user.Contact_Num1,
                Contact_Num2 = user.Contact_Num2,
            };

            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (!result.Succeeded)
                return Result.Failure(new List<string>() { "Error: account creation failed." });

            await _userManager.UpdateSecurityStampAsync(appUser);

            await _userManager.AddToRoleAsync(appUser, UserRoleOptions.User.ToString());

            await _signInManager.SignInAsync(appUser, isPersistent: true);

            // Store 
            // Images

            return Result.Success();
        }
    }
}
