using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cerberus.Dashboard.Domain.Models
{
    public abstract class BaseAnalyticModel
    {
        [Key]
        public int Id { get; set; }
        public int Sum { get; set; }

        public DateTime DateRecord { get; set; }
        public int LastSum { get; set; }
        public DateTime LastDateRecord { get; set; }
        public string AnalyticType { get; set; }



    }
}
