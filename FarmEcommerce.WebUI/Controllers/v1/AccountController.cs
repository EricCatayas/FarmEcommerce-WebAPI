using ContactsManagement.Core.DTO.ContactsManager;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Stores;
using FarmEcommerce.Core.Services.Stores;
using FarmEcommerce.Infrastructure.Identity;
using FarmEcommerce.WebUI.Controllers;
using FarmEcommerce.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace FarmEcommerce.Web.Controllers.v1
{
    [ApiVersion("1.0")]

    public class AccountController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserRegistrationService _registerUserService;

        public AccountController(IIdentityService identityService, IUserRegistrationService registerUserService)
        {
            _identityService = identityService;
            _registerUserService = registerUserService;
        }
        [AllowAnonymous]
        [HttpPost]
        [ModelValidationFilter]
        public async Task<ActionResult<Result>> Login(LoginDTO loginDTO, bool RememberMe = true)
        {            
            return await _identityService.SignInUserAsync(loginDTO.Email, loginDTO.Password, RememberMe);
        }
        
        [AllowAnonymous]
        [HttpPost]
        [ModelValidationFilter]
        public async Task<ActionResult<Result>> Register(RegisterDTO registerDTO)
        {

            return await _registerUserService.CreateUserAsync(registerDTO);
        }
        [HttpGet]
        public async Task<ActionResult<Result>> Logout()
        {
            return await _identityService.SignOutUserAsync();
        }
        [HttpGet]
        public async Task<ActionResult<bool>> IsEmailAlreadyRegistered(string email)
        {
            return await _registerUserService.IsEmailAddressRegistered(email) ? new JsonResult(true) : new JsonResult(false); //The browser can only recieve the json result
        }
    }
}
