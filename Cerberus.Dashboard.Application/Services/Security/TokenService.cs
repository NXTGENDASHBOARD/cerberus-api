using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
namespace Cerberus.Dashboard.Application.Services.Security
{
    public interface ITokenService
    {
        string BuildToken(string name, string[] roles, DateTime expireDate);
    }

    public class TokenService : ITokenService
    {
        public string BuildToken(string name, string[] roles, DateTime expireDate)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = roles.Select(role =>
                                       new Claim(ClaimTypes.Role, role)).ToList();

            var identity = new ClaimsIdentity(new GenericIdentity(name, TokenAuthOption.TokenType), claims);
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expireDate
            });

            return handler.WriteToken(securityToken);
        }

        public string BuildItsToken(string staffNumber, string pin, string key)
        {

            return null;
        }

    }
}
