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
using FarmEcommerce.WebUI.Filters.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Security.Claims;

namespace FarmEcommerce.Web.Controllers.v1
{
    /// <summary>
    /// Controller responsible for handling account-related operations.
    /// </summary>    
    [ApiVersion("1.0")]
    [TypeFilter(typeof(ServiceUnavailableFilter))]
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

        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        /// <response code="400">Account was not logged in due to validation errors.</response>
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
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        /// <response code="401">Token is unauthenticated.</response>
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> LoginWithToken(string token)
        {
            try
            {
                ClaimsPrincipal principal = _jwtService.GetPrincipalFromJwtToken(token);

                Claim userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    string userId = userIdClaim.Value;
                    var user = await _identityService.GetUserAsync(userId);

                    //var newToken = _jwtService.CreateJwtToken(user);
                    return Ok(user);
                }
                else
                {
                    return Unauthorized("Token is not authenticated.");
                }
            }
            catch
            {
                // TODO
                return  Unauthorized("Token is not authenticated.");
            }
        }
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        /// <response code="400">Account was not registered due to validation errors.</response>
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
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<Result>> Logout()
        {
            return await _identityService.SignOutUserAsync();
        }
        /// <remarks>
        /// **DO NOT USE**. This Api is currently not available.
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<bool>> IsEmailAlreadyRegistered(string email)
        {
            return await _registerUserService.IsEmailAddressRegistered(email) ? new JsonResult(true) : new JsonResult(false); //The browser can only recieve the json result
        }
    }
}
