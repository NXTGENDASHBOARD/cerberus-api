using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public  class Faculty : Entity
    {
        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public virtual List<School> Schools { get; set;}

    }
}
