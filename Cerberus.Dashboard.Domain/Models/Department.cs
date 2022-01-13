using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Department : AuditEntity<int>
    {
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public  List<Courses> Courses { get; set; }
    }
}
