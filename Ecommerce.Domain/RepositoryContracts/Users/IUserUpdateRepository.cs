
namespace Ecommerce.Domain.RepositoryContracts.Users
{
    public interface IUserUpdateRepository
    {
        Task<IBaseUserEntity> UpdateAsync(IBaseUserEntity user);
    }
}
