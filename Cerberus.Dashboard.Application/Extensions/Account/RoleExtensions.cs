using Cerberus.Dashboard.Application.ViewModels.Account;
using Cerberus.Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions.Account
{
    public static class RoleExtensions
    {

        public static RoleResponseViewModel ToViewModelEntity(this Role role, List<RolePermission> permissions = null)
        {
            return new RoleResponseViewModel
            {
                RoleName = role.RoleName,
                Description = role.Description,
                Permissions = permissions?.Select(x => x.Permission.ToViewModelEntity()).ToList(),
            };
        }

        public static PermissionResponseViewModel ToViewModelEntity(this Permission permission)
        {
            return new PermissionResponseViewModel
            {
                PermissionName = permission.PermissionName,
                Description = permission.Description,
            };
        }
    }
}
