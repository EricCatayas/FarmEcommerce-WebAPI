namespace Ecommerce.Domain.RepositoryContracts.Addresses
{
    public interface IMunicipalitiesGetRepository
    {
        public Task<IEnumerable<Municipality>> GetAsync(int province_Id);
    }
}
