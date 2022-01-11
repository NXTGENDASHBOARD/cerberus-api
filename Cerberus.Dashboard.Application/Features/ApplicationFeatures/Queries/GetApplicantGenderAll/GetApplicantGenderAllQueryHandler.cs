using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantGenderAll
{
    public class GetApplicantGenderAllQueryHandler : IRequestHandler<GetApplicantGenderAllQuery, IEnumerable<Domain.Models.GenderApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantGenderAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GenderApplicationAnalytic>> Handle(GetApplicantGenderAllQuery request, CancellationToken cancellationToken)
        {
            var genderApplicationList = await _context.GenderApplicationAnalytic.ToListAsync();
            if (genderApplicationList == null)
                return null;

            return genderApplicationList.AsReadOnly();
        }
    }
}
