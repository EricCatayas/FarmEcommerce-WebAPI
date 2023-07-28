
namespace Ecommerce.Domain.RepositoryContracts.Users
{
    public interface IUserGetRepository
    {
        public Task<IBaseUserEntity> GetUserById(Guid id);
    }
}
