using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class AccountResponseViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Token { get; set; }

        public bool IsActive { get; set; }

        public string OTP { get; set; }
        public bool IsVerified { get; set; }

        public int StatusId { get; set; }

    }
}
