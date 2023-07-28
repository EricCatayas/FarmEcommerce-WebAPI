
using FarmEcommerce.Core.Common.DTO;

namespace FarmEcommerce.Core.ServiceContracts.Users
{
    public interface IUserGetService
    {
        public Task<UserDTO> GetUserById(Guid user_Id);
    }
}
