using CitiesManager.Core.ServiceContracts;
using Ecommerce.Domain.Common;
using FarmEcommerce.Core.Common.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FarmEcommerce.Infrastructure.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    /// <summary>
    /// Generates a JWT token using the given user's information and the configuration settings.
    /// </summary>
    /// <param name="user">ApplicationUser object</param>
    /// <returns>AuthenticationResponse that includes token</returns>
    public AuthenticationResponse CreateJwtToken(IBaseUserEntity user)
    {
        DateTime expiration = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:EXPIRATION_DAYS"]));


        Claim[] userClaims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), //Subject (user id)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JWT unique ID
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()), //Issued at (date and time of token generation)
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), //Unique name identifier of the user (Email)
            new Claim(ClaimTypes.Name, user.UserName), //Name of the user
            new Claim(ClaimTypes.Email, user.Email) //Email of the user
        };

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Create a JwtSecurityToken object with the given issuer, audience, claims, expiration, and signing credentials.
        JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],  
            userClaims,
            expires: expiration,
            signingCredentials: signingCredentials
        );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string token = tokenHandler.WriteToken(tokenGenerator);

        // Create and return an AuthenticationResponse object containing the token, user email, user name, and token expiration time.
        return new AuthenticationResponse() 
        { 
            Token = token, 
            Email = user.Email, 
            PersonName = user.UserName, 
            Expiration = expiration,
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpirationDateTime = DateTime.Now.AddDays(Convert.ToInt32(_configuration["RefreshToken:EXPIRATION_DAYS"]))
        };
    }


    private string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];
        var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }


    public ClaimsPrincipal? GetPrincipalFromJwtToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidAudience = _configuration["Jwt:Audience"],
            ValidateIssuer = true,
            ValidIssuer = _configuration["Jwt:Issuer"],

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),

            ValidateLifetime = false 
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        ClaimsPrincipal principal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

    
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase) )
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}
