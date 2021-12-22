using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public  class Address : Entity
    {
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }
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
    }
}
