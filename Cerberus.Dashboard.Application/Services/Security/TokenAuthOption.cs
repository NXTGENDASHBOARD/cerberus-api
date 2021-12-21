using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Services.Security
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "CerberusAudience";
        public static string Issuer { get; } = "CerberusIssuer";

        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(60);
        public static string TokenType { get; } = "Bearer";
    }

    public class RSAKeyHelper
    {
        public static RSAParameters GenerateKey()
        {
            using var key = new RSACryptoServiceProvider(2048);
            return key.ExportParameters(true);
        }
    }
}
