
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using Microsoft.EntityFrameworkCore;

namespace FarmEcommerce.Core.Services.Addresses
{
    public class AddressGetService : IAddressGetService
    {
        private readonly IApplicationDbContext _dbContext;

        public AddressGetService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Address> GetAddress(int id)
        {
            var result = await _dbContext.Addresses.Include(a => a.City).Include(a => a.Region).FirstOrDefaultAsync(a => a.Id == id);
            if(result == null)            
                throw new DataNotFoundException(typeof(Address), id);
            
            return result;
        }
        public async Task<IEnumerable<Address>> GetUserAddressList(Guid user_Id)
        {           
            var user_addresses = await (from address in _dbContext.Addresses
                                        join user_address in _dbContext.User_Addresses
                                        on address.Id equals user_address.Address_Id
                                        where user_address.User_Id == user_Id
                                        join city in _dbContext.Cities
                                        on address.City_Id equals city.Id
                                        join region in _dbContext.Regions
                                        on address.Region_Id equals region.Id
                                        select new Address {
                                            Id = address.Id,
                                            Street = address.Street,
                                            Barangay = address.Barangay,
                                            City = city,
                                            City_Id = address.City_Id,
                                            Region = region,
                                            Postal_Code = address.Postal_Code,
                                            Region_Id = address.Region_Id
                                        }).ToListAsync();
            return user_addresses;
        }
    }
}
