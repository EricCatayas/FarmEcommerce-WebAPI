using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.DTO;
using System.Security.Claims;

namespace CitiesManager.Core.ServiceContracts
{
 public interface IJwtService
 {
  AuthenticationResponse CreateJwtToken(IBaseUserEntity user);
  ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
 }
}
