using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class AccountVerificationOtpViewModel
    {
        public string OTPVerification { get; set; }
    }

    public class AccountVerificationRequestOtpViewModel
    {
        public string Email { get; set; }
    }
}
