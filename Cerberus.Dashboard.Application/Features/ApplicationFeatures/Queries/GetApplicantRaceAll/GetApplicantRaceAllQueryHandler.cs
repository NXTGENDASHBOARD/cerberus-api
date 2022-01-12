using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;


namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantRaceAll
{
    public class GetApplicantRaceAllQueryHandler : IRequestHandler<GetApplicantRaceAllQuery, IEnumerable<Domain.Models.RaceGraphModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantRaceAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceGraphModel>> Handle(GetApplicantRaceAllQuery request, CancellationToken cancellationToken)
        {
            var raceApplicationList = await _context.RaceApplicationAnalytic.ToListAsync();
            List<RaceGraphModel> model = new List<RaceGraphModel>();
            if (raceApplicationList == null)
            {
                return null;
            }
            else
            {
                foreach (var race in raceApplicationList.OrderByDescending(g => g.DateRecord).Take(5))
                {
                    RaceGraphModel app = new RaceGraphModel
                    {
                        DateRecord = race.DateRecord,
                        Race = race.AnalyticType,
                        Sum = race.Sum
                    };
                    if (race.LastSum != 0)
                    {
                        app.Trend = Math.Round(Decimal.Divide(race.Sum, race.LastSum), 2) * 100;
                    }
                    else
                    {
                        app.Trend = 0;
                    }

                    model.Add(app);
                }
            }

            return model;
        }
    }
}
