using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Addresses
{
    public class AddressUpdateService : IAddressUpdateService
    {
        private readonly IRepository<Address> _addressRepo;
        private readonly IReadRepository<Municipality> _cityRepo;

        public AddressUpdateService(IRepository<Address> addressRepo, IReadRepository<Municipality> cityRepo)
        {
            _addressRepo = addressRepo;
            _cityRepo = cityRepo;
        }
        public async Task<Result> UpdateAsync(AddressUpdateDTO address)
        {
            var prev_address = await _addressRepo.GetByIdAsync(address.Id);
            var city = await _cityRepo.GetByIdAsync(address.Municipality_Id);

            if(prev_address == null)
            {
                throw new DataNotFoundException(typeof(Address), address.Id);
            }
            if(city == null)
            {                
                throw new DataNotFoundException(typeof(Municipality),address.Municipality_Id);
            }
            //Update
            prev_address.Street = address.Street;
            prev_address.Barangay = address.Barangay;
            prev_address.Municipality_Id = address.Municipality_Id;
            prev_address.Province_Id = city.Province_Id;
            prev_address.Postal_Code = address.Postal_Code;
            // prev_address.Latitude
            // prev_address.Longitude 
            await _addressRepo.SaveChangesAsync();
            return Result.Success();
        }
    }
}
