using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantCourseTypeAll
{
    public class GetApplicantCourseTypeAllQuery : IRequest<IEnumerable<Domain.Models.CourseTypeApplicationAnalytic>>
    {
        public bool isPaginated { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}
