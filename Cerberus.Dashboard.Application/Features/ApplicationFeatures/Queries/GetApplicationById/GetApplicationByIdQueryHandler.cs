using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationById
{
    public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, Domain.Models.Application>
    {

        private readonly IApplicationDbContext _context;

        public GetApplicationByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Models.Application> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken: cancellationToken);

            if (application == null)
            {
                return null;
            }

            else
            {
                application.Institution = await _context.Institutions.FirstOrDefaultAsync(i => i.Id == application.InstitutionId, cancellationToken: cancellationToken);
                application.Courses = await _context.Courses.Where(c => c.ApplicationId == application.Id).ToListAsync(cancellationToken: cancellationToken);
                application.Address = await _context.Addresss.FirstOrDefaultAsync(a => a.Id == application.AddressId, cancellationToken: cancellationToken);
                application.Institution.Address = await _context.Addresss.FirstOrDefaultAsync(a => a.Id == application.Institution.AddressId, cancellationToken: cancellationToken);
                application.Institution.Faculties = await _context.Faculty.Where( f => f.InstitutionId == application.InstitutionId).ToListAsync(cancellationToken: cancellationToken);

                foreach (Domain.Models.Faculty f in application.Institution.Faculties)
                {
                    f.Schools =  await _context.School.Where( s => s.FacultyId == f.Id).ToListAsync(cancellationToken: cancellationToken);

                    foreach (Domain.Models.School s in f.Schools)
                    {
                        s.Departments = await _context.Department.Where(d => d.SchoolId == s.Id).ToListAsync(cancellationToken:cancellationToken);

                        foreach (Domain.Models.Department d in s.Departments)
                        {
                            d.Courses = await _context.Courses.Where(c =>  c.ApplicationId == application.Id).ToListAsync(cancellationToken: cancellationToken); 
                        }
                    }
                }
               
            }
            return application;
        }

    }
}
