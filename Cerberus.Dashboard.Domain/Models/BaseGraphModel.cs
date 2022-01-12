using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class BaseGraphModel
    {
        public int Sum { get; set; }
        public DateTime DateRecord { get; set; }
        public decimal Trend { get; set; }
    }
}
