
namespace Ecommerce.Domain.RepositoryContracts.Regions
{
    public interface IRegionGetRepository
    {
        Task<List<Region>> GetAll();
    }
}
