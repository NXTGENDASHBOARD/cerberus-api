using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class LoginAccountViewModel
    {
        [Required]
        public string StaffNumber { get; set; }
        [Required]
        public string Pin { get; set; }
    }
}
