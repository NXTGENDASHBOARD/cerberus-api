using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Cerberus.Dashboard.Application.Services.Security
{
    public interface IEncryptionService
    {
        bool IsValidPassword(string password, string passwordHash);
    }

    public class EncryptionService : IEncryptionService
    {
        public bool IsValidPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
