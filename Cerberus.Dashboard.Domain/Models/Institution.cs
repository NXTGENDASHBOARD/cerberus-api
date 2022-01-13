using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Institution : AuditEntity<int>
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public  List<Faculty> Faculties { get; set; }
    }
}
