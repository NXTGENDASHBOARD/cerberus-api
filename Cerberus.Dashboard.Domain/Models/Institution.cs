using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class Institution : Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public Address Address { get; set; }
    }
}
