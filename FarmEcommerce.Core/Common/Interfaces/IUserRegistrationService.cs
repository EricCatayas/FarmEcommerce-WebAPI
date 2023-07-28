
using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.Common.Interfaces
{
    public interface IUserRegistrationService
    {
        Task<Result> CreateUserAsync(RegisterDTO user);
    }
}
