using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantCourseTypeAll
{
    public class GetApplicantCourseTypeAllQueryHandler : IRequestHandler<GetApplicantCourseTypeAllQuery, IEnumerable<Domain.Models.CourseTypeApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantCourseTypeAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseTypeApplicationAnalytic>> Handle(GetApplicantCourseTypeAllQuery request, CancellationToken cancellationToken)
        {
            var courseTypeApplicationList = await _context.CourseTypeApplicationAnalytic.ToListAsync();
            if (courseTypeApplicationList == null)
                return null;

            return courseTypeApplicationList.AsReadOnly();
        }
    }
}
