
using Ecommerce.Domain.Entities;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.ServiceContracts.Addresses;
using FarmEcommerce.WebUI.ApiModels;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Core.Services.Addresses
{
    public class AddressCreateService : IAddressCreateService
    {
        private readonly IRepository<Address> _addressRepo;
        private readonly IReadRepository<City> _cityRepo;
        private readonly IRepository<User_Address> _userAddressRepo;
        private readonly IGetSignedInUserService _signedInUserService;

        public AddressCreateService(IRepository<Address> addressRepo, IReadRepository<City> cityRepo, IRepository<User_Address> userAddressRepo, IGetSignedInUserService signedInUserService)
        {
            _addressRepo = addressRepo;
            _cityRepo = cityRepo;
            _userAddressRepo = userAddressRepo;
            _signedInUserService = signedInUserService;
        }
        public async Task<Address> CreateAsync(AddressCreateDTO address)
        {
            if(ValidationHelper.ModelInValid(address, out string message))
            {
                throw new ArgumentException(message);
            }
            var city = await _cityRepo.GetByIdAsync(address.City_Id);
            var user = await _signedInUserService.GetSignedInUser();
            if(city == null)            
                throw new DataNotFoundException(typeof(City), address.City_Id);
            if (user == null)
                throw new RequestDeniedException();
            try
            {
                var result = await _addressRepo.AddAsync(new Address()
                {
                    Barangay = address.Barangay,
                    Street = address.Street,
                    City_Id = city.Id,
                    Region_Id = city.Region_Id
                });
                await _userAddressRepo.AddAsync(new User_Address() { User_Id = user.Id, Address_Id = result.Id });

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
