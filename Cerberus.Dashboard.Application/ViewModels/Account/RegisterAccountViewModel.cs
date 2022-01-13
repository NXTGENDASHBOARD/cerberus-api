using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class RegisterAccountViewModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public string StaffNumber { get; set; }
        public string Password { get; set; }

        public bool IsThirdParty { get; set; }

        public string ThirdPartyProvider { get; set; }

        public string RoleType { get; set; }
        public string CreateUserId { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsVerified { get; set; }
        public string OTPVerification { get; set; }
        public bool IsActive { get; set; } = true;
        public int StatusId { get; set; }
    }
}
