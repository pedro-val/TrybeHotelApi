using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Services
{
    public class TokenGenerator
    {
        private readonly TokenOptions _tokenOptions;
        public TokenGenerator()
        {
           _tokenOptions = new TokenOptions {
                Secret = "4d82a63bbdc67c1e4784ed6587f3730c",
                ExpiresDay = 1
           };

        }
        public string Generate(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenOptions.Secret ?? string.Empty)),
                SecurityAlgorithms.HmacSha256Signature),

                Expires = DateTime.UtcNow.AddYears(_tokenOptions.ExpiresDay),
                Subject = AddClaims(user),
                Issuer = "localhost",
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity AddClaims(UserDto user)
        {   
            ClaimsIdentity claims = new();
            if (user.UserType == "admin")
            {
                Claim roleClaim = new(ClaimTypes.Role, user.UserType);
                claims.AddClaim(roleClaim);
            }
            Claim emailClaim = new(ClaimTypes.Email, user.Email);
            claims.AddClaim(emailClaim);
            return claims;
        }
    }
}