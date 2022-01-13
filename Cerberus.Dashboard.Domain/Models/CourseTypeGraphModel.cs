using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
{
    public class CourseTypeGraphModel : BaseGraphModel
    {
        public string Course { get; set; }
        public List<Series> CourseSeries { get; set; }

        public class Series
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
