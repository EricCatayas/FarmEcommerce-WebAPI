namespace Ecommerce.Domain.RepositoryContracts.Addresses
{
    public interface IProvincesGetRepository
    {
        Task<IEnumerable<Province>> GetAll();
    }
}
