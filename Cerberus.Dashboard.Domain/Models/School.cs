using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public  class School : AuditEntity<int>
    {
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public string Name { get; set; }

        public  List<Department> Departments { get; set; }
        
    }
}
