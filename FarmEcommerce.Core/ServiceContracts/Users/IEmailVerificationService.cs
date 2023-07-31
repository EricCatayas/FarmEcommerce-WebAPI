
namespace FarmEcommerce.Core.ServiceContracts.Users
{
    public interface IEmailVerificationService
    {
        Task<bool> IsEmailAddressRegistered(string email);
    }
}
