using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Permission : AuditEntity<int>
    {
        [MaxLength(256)]
        public string PermissionName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
