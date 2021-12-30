using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Application : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string ApplicationDate { get; set; }
        public bool IsDisable { get; set; }
        public string ApplicationStage { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Courses> Courses { get; set; }
        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }

        
    }
}
