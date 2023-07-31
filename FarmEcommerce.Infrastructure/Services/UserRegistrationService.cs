
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.RepositoryContracts.Images;
using FarmEcommerce.Core.Common.DTO;
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
        public async Task<Result> CreateUserAsync(RegisterDTO user)
        {
            if(ValidationHelper.ModelInValid(user, out string errorMessage))
            {
                return Result.Failure(new List<string>() { errorMessage });
            }

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
                {                
                    return Result.Failure( result.Errors.Select(x => x.Description).ToList() );
                }

                await _userManager.UpdateSecurityStampAsync(appUser);

                await _userManager.AddToRoleAsync(appUser, UserRoleOptions.User.ToString());

                //Images & Store
                appUser.Images = await _imagesRepo.AddAsync(userImages);
                store.Images = await _imagesRepo.AddAsync(storeImages);
                appUser.Store = await _storeRepo.AddAsync(store);

                await _userManager.UpdateAsync(appUser);
                await _signInManager.SignInAsync(appUser, isPersistent: true);

                return Result.Success();
            }
            catch(Exception ex)
            {
                await _userManager.DeleteAsync(appUser);
                await _imagesRepo.DeleteAsync(userImages);
                await _imagesRepo.DeleteAsync(storeImages);
                await _storeRepo.DeleteAsync(store);
                return Result.Failure(new List<string>() { ex.Message });
            }
        }

        public async Task<bool> IsEmailAddressRegistered(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            return user != null ? true : false;
        }
    }
}
