using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<IBaseUserEntity?> GetUserAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);        
        Task<Result> SignInUserAsync(string userName, string password, bool isPersistent = true);
        Task<Result> SignOutUserAsync();

        Task<Result> DeleteUserAsync(string userId);
    }
}
