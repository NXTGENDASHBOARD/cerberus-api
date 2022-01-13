using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
using Cerberus.Dashboard.Application.Constants;
using Microsoft.Extensions.Options;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Services.Security
{
    public interface ITokenService
    {
        string BuildToken(Account model, string[] roles, DateTime expireDate);
        int? ValidateToken(string token);
    }

    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string BuildToken(Account model, string[] roles, DateTime expireDateTime)
        {

            var handler = new JwtSecurityTokenHandler();


            var claims = new[] {
                new Claim("id", model.Id.ToString()),
                new Claim(ClaimTypes.Name, model.Email)
            }.ToList();

            claims.AddRange(roles.Select(role =>
                                 new Claim(ClaimTypes.Role, role)).ToList());

            var identity = new ClaimsIdentity(claims);

            var key = Encoding.ASCII.GetBytes(_appSettings.AppSecret);

            var signingKey = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                SigningCredentials = signingKey,
                Subject = identity,
                Expires = expireDateTime
            });

            return handler.WriteToken(securityToken);
        }

        public string BuildItsToken(string staffNumber, string pin, string key)
        {

            return null;
        }

        public int? ValidateToken(string token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.AppSecret);
            try
            {

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

    }
}
