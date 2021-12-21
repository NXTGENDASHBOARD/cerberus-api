using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Account : Entity
    {

        // Properties
        [Required]
        public string StaffNumber { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        // Security
        public string PasswordHash { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string Token { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        
        public List<RefreshToken> RefreshTokens { get; set; }
        public int RegistrationTypeId { get; set; }


        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }


    [Owned]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public Account Account { get; set; }
        public string Token { get; set; }

        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;

        public DateTime CreateDate { get; set; }
        public string CreatedByIp { get; set; }

        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }

        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
    public enum Role
    {
        Admin = 1,
        Staff = 2,
        Student = 3
    }
}
