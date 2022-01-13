using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Account
{
    public class RoleResponseViewModel
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        public List<PermissionResponseViewModel> Permissions { get; set; }

        public RoleResponseViewModel()
        {
            Permissions = new List<PermissionResponseViewModel>();
        }
    }
}
