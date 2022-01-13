using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public  class Courses : AuditEntity<int>
    {
        
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public string Preference { get; set; }
        public string Name { get; set; }

    }
}
