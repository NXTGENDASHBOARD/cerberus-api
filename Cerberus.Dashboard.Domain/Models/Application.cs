using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string PhysicalAddressLine3 { get; set; }
        public string PhysicalAddressCity { get; set; }
        public string PhysicalAddressPostalCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalAddressLine3 { get; set; }
        public string PostalAddressCity { get; set; }
        public string PostalAddressPostalCode { get; set; }
        public List<Courses> Courses { get; set; }


    }
}
