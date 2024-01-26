
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.RepositoryContracts.Images;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Exceptions;
using FarmEcommerce.Core.Common.Helpers;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace FarmEcommerce.Infrastructure.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Images> _imagesRepo;
        private readonly IRepository<Store> _storeRepo;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRegistrationService(UserManager<ApplicationUser> userManager, 
                                       SignInManager<ApplicationUser> signInManager,
                                       IRepository<Images> imagesRepo,
                                       IRepository<Store> storeRepo)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _imagesRepo = imagesRepo;
            _storeRepo = storeRepo;
        }
        public async Task<IBaseUserEntity> CreateUserAsync(RegisterDTO user)
        {
            if(ValidationHelper.ModelInValid(user, out string errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            if (await IsEmailAddressRegistered(user.Email))
                throw new RegistrationException("Email is already taken");

            var appUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Email = user.Email,
                Contact_Num1 = user.Contact_Num1,
                Contact_Num2 = user.Contact_Num2,
            };
            var userImages = new Images() {};
            var storeImages = new Images() {};
            var store = new Store()
            {
                Name = $"{user.UserName}'s Store",
                Established_Date = DateTime.Now,
                Images_Id = storeImages.Id,
                Owner_Id = appUser.Id
            };
            
            try
            {

                var result = await _userManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)                
                    throw new RegistrationException();
                    //throw new Exception(result.Errors.Select(x => x.Description));
                

                await _userManager.UpdateSecurityStampAsync(appUser);

                await _userManager.AddToRoleAsync(appUser, UserRoleOptions.User.ToString());

                //Images & Store
                appUser.Images = await _imagesRepo.AddAsync(userImages);
                store.Images = await _imagesRepo.AddAsync(storeImages);
                appUser.Store = await _storeRepo.AddAsync(store);

                await _userManager.UpdateAsync(appUser);
                await _signInManager.SignInAsync(appUser, isPersistent: true);

                return appUser;
            }
            catch
            {
                var deleteUserTask = _userManager.DeleteAsync(appUser);
                var deleteImagesTask = _imagesRepo.DeleteAsync(userImages);
                var deleteStoreImagesTask = _imagesRepo.DeleteAsync(storeImages);
                var deleteStoreTask = _storeRepo.DeleteAsync(store);

                await Task.WhenAll(deleteUserTask, deleteImagesTask, deleteStoreImagesTask, deleteStoreTask);
                throw;
            }
        }

        public async Task<bool> IsEmailAddressRegistered(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            return user != null ? true : false;
        }
    }
}
