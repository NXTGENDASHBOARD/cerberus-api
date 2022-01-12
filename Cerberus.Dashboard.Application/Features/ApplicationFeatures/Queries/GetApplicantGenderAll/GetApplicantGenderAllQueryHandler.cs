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
    public class GetApplicantGenderAllQueryHandler : IRequestHandler<GetApplicantGenderAllQuery, IEnumerable<Domain.Models.GenderGraphModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantGenderAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GenderGraphModel>> Handle(GetApplicantGenderAllQuery request, CancellationToken cancellationToken)
        {
            var genderApplicationList = await _context.GenderApplicationAnalytic.ToListAsync();
            List<GenderGraphModel> model = new List<GenderGraphModel>();
            if (genderApplicationList == null)
            {
                return null;
            }
            else
            {
                //get the sum for the latest specific date
                foreach(GenderApplicationAnalytic genderApplication in genderApplicationList.OrderByDescending(g  => g.DateRecord).Take(3))
                {
                    GenderGraphModel app = new GenderGraphModel
                    {
                        DateRecord = genderApplication.DateRecord,
                        Gender = genderApplication.AnalyticType,
                        Sum = genderApplication.Sum
                    };
                    if (genderApplication.LastSum != 0)
                    {
                        app.Trend = Math.Round(Decimal.Divide(genderApplication.Sum, genderApplication.LastSum), 2) * 100;
                    }
                    else
                    {
                        app.Trend = 0;
                    }
                    
                    model.Add(app);





                }
            }

            return model.AsReadOnly();
        }
    }
}
