
using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.ServiceContracts.Users;

namespace FarmEcommerce.Core.Common.Interfaces
{
    public interface IUserRegistrationService : IEmailVerificationService
    {
        Task<Result> CreateUserAsync(RegisterDTO user);
    }
}
