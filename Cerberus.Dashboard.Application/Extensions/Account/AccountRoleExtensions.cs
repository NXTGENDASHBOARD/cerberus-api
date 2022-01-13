using Cerberus.Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions.Account
{
    public static class AccountRoleExtensions
    {
        public static AccountRole ToEntityAccountRole(this Domain.Models.Account model, Role role)
        {
            return new AccountRole
            {
                AccountId = model.Id,
                RoleId = role.Id,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = model.CreateUserId,
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = model.ModifyUserId,
                IsActive = true,
                StatusId = 1,// Active
            };
        }
    }
}
