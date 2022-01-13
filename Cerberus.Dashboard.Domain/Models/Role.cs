using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Role : AuditEntity<int>
    {
        [MaxLength(256)]
        public string RoleName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public virtual List<RolePermission> Permissions { get; set; }

        public Role()
        {
            Permissions = new List<RolePermission>();
        }
    }
}
