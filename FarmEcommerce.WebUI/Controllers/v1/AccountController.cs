using CitiesManager.Core.ServiceContracts;
using ContactsManagement.Core.DTO.ContactsManager;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Interfaces;
using FarmEcommerce.Core.ServiceContracts.Stores;
using FarmEcommerce.Core.Services.Stores;
using FarmEcommerce.Infrastructure.Identity;
using FarmEcommerce.Infrastructure.Services;
using FarmEcommerce.WebUI.Controllers;
using FarmEcommerce.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace FarmEcommerce.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    [AllowAnonymous]

    public class AccountController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserRegistrationService _registerUserService;
        private readonly IJwtService _jwtService;

        public AccountController(IIdentityService identityService, IUserRegistrationService registerUserService, IJwtService jwtService)
        {
            _identityService = identityService;
            _registerUserService = registerUserService;
            _jwtService = jwtService;
        }
        
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] LoginDTO loginDTO,[FromQuery] bool RememberMe = true)
        {
            try
            {
                var result = await _identityService.SignInUserAsync(loginDTO.Email, loginDTO.Password, RememberMe);

                return _jwtService.CreateJwtToken(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        //[ModelValidationFilter]
        public async Task<ActionResult<AuthenticationResponse>> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                var result = await _registerUserService.CreateUserAsync(registerDTO);

                return _jwtService.CreateJwtToken(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
