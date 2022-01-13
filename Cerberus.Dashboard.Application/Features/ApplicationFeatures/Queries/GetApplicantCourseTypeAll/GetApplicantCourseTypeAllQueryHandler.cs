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
    public class GetApplicantCourseTypeAllQueryHandler : IRequestHandler<GetApplicantCourseTypeAllQuery, IEnumerable<Domain.Models.CourseTypeGraphModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantCourseTypeAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseTypeGraphModel>> Handle(GetApplicantCourseTypeAllQuery request, CancellationToken cancellationToken)
        {
            var courseTypeApplicationList = await _context.CourseTypeApplicationAnalytic.ToListAsync();
            List<CourseTypeGraphModel> courses = new List<CourseTypeGraphModel>();
            if (courseTypeApplicationList == null)
            {
                return null;
            }
            else
            {
                foreach (var courseType in courseTypeApplicationList.OrderByDescending(g => g.DateRecord).Take(6))
                {
                    CourseTypeGraphModel course = new CourseTypeGraphModel();
                    course.Course = courseType.AnalyticType;
                    course.Sum = courseType.Sum;
                    course.DateRecord = courseType.DateRecord;
                    if (courseType.LastSum != 0)
                    {
                        course.Trend = Math.Round(Decimal.Divide(courseType.Sum, courseType.LastSum), 2) * 100;
                    }
                    else
                    {
                        course.Trend = 0;
                    }
                    course.CourseSeries = new List<CourseTypeGraphModel.Series>();
                    course.CourseSeries.Add(new CourseTypeGraphModel.Series
                    {
                        Name= "Nr of Applications",
                        Value = courseType.Sum
                    }
                    );
                    course.CourseSeries.Add(new CourseTypeGraphModel.Series
                    {
                        Name = "Nr of spaces still available",
                        Value = courseType.Sum - (int)Math.Round(Decimal.Divide(courseType.Sum,2),0)
                    }
                    );
                    courses.Add(course);
                }
            }
                

            return courses.AsReadOnly();
        }
    }
}
