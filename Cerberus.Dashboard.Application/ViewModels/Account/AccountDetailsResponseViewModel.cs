using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class AccountDetailsResponseViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string StaffNumber { get; set; }

        public string Token { get; set; }

        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int StatusId { get; set; }

        public List<RoleResponseViewModel> Roles { get; set; }

        public AccountDetailsResponseViewModel()
        {
            Roles = new List<RoleResponseViewModel>();
        }

    }
}
