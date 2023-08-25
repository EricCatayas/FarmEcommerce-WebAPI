using CitiesManager.Core.ServiceContracts;
using CleanArchitecture.Infrastructure.Identity;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Enums;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FarmEcommerce.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<IBaseUserEntity?> GetUserAsync(string userId)
    {
        if (!Guid.TryParse(userId, out var parsedId))
            return null;

        var user = await _userManager.Users.FirstAsync(u => u.Id == parsedId);
        return user;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        if (Guid.TryParse(userId, out var parsedId))
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == parsedId);
            return user != null && await _userManager.IsInRoleAsync(user, role);
        }
        return false;

    }
    public async Task<IBaseUserEntity> SignInUserAsync(string email, string password, bool isPersistent = true)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Email == email);
        if (user == null)
            throw new UnauthorizedAccessException("Email is incorrect");

        var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return user;
        }
        else
        {
            throw new UnathorizedRequestException("Password is incorrect");
        }
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        if (!Guid.TryParse(userId, out var parsedId))
            return false;

        var user = _userManager.Users.SingleOrDefault(u => u.Id == parsedId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        if (!Guid.TryParse(userId, out var parsedId))
            return Result.Failure(new List<string>() { "Invalid User Id" });

        var user = _userManager.Users.SingleOrDefault(u => u.Id == parsedId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<Result> SignOutUserAsync()
    {
        await _signInManager.SignOutAsync();
        return Result.Success();
    }
}
