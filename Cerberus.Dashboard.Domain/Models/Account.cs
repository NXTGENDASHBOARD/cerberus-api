using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Account : AuditEntity<int>
    {

        // Properties
        public string StaffNumber { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public bool IsThirdParty { get; set; }

        public string ThirdPartyProvider { get; set; }
        public string Token { get; set; }
        public bool IsVerified { get; set; }
        public string OTPVerification { get; set; }

        public DateTime? OTPTokenExpires { get; set; }

        public virtual List<AccountRole> Roles { get; set; }

        public Account()
        {
            Roles = new List<AccountRole>();
        }
    }
 
    public enum RoleEnum
    {
        Admin = 1,
        Dean = 2,
        Lecturer = 3
    }

    public static class RoleConstants
    {
        public const string Admin = "Admin";
        public const string Dean = "Dean";
        public const string Lecturer = "Lecturer";
        public const string FacultyOfficer = "Faculty Officer";
    }
}
