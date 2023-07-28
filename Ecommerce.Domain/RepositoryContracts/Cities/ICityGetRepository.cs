
namespace Ecommerce.Domain.RepositoryContracts.Cities
{
    public interface ICityGetRepository
    {
        public Task<IEnumerable<City>> GetAll();    
    }
}
