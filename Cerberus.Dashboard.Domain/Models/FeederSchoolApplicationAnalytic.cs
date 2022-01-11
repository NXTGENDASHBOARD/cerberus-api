using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class FeederSchoolApplicationAnalytic : BaseAnalyticModel
    {
        public string FeederSchoolName { get; set;}
        public string Quintile { get; set;}
    }
}
