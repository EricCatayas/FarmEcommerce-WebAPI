
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
        private readonly IReadRepository<Municipality> _cityRepo;
        private readonly IRepository<User_Address> _userAddressRepo;
        private readonly IGetSignedInUserService _signedInUserService;

        public AddressCreateService(IRepository<Address> addressRepo, IReadRepository<Municipality> cityRepo, IRepository<User_Address> userAddressRepo, IGetSignedInUserService signedInUserService)
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
            try
            {
                var city = await _cityRepo.GetByIdAsync(address.Municipality_Id);
                var user = await _signedInUserService.GetSignedInUser();
                if(city == null)            
                    throw new DataNotFoundException(typeof(Municipality), address.Municipality_Id);

                var result = await _addressRepo.AddAsync(new Address()
                {
                    Barangay = address.Barangay,
                    Street = address.Street,
                    Municipality_Id = city.Id
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
