using ContactsManagement.Core.DTO.ContactsManager;
using FarmEcommerce.Core.Common.DTO;
using FarmEcommerce.Core.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace ContactsManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserRegistrationService _registerUserService;

        public AccountController(IIdentityService identityService, IUserRegistrationService registerUserService)
        {
            _identityService = identityService;
            _registerUserService = registerUserService;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<Result>> Login(LoginDTO loginDTO, bool RememberMe = true)
        {
            if (!ModelState.IsValid)
            {
                return Result.Failure(ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage));
            }
            return await _identityService.SignInUserAsync(loginDTO.Email, loginDTO.Password, RememberMe);
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Result>> Register(RegisterDTO registerDTO)
        {
            if(!ModelState.IsValid)
            {
                return Result.Failure(ModelState.Values.SelectMany(V => V.Errors).Select(err => err.ErrorMessage));        
            }

            return await _registerUserService.CreateUserAsync(registerDTO);
           
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Result>> Logout()
        {
            return await _identityService.SignOutUserAsync();
        }
    }
}
