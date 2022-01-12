using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationsCompleted
{
    public class GetApplicationsCompletedQueryHandler : IRequestHandler<GetApplicationsCompletedQuery, IEnumerable<Domain.Models.AppGaugeGraphModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicationsCompletedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppGaugeGraphModel>> Handle(GetApplicationsCompletedQuery request, CancellationToken cancellationToken)
        {
            var completedApplicationList = await _context.CompletedApplicationAnalytic.ToListAsync();
            List<AppGaugeGraphModel> model = new List<AppGaugeGraphModel>();
            if (completedApplicationList == null)
            {
                return null;
            }
            else
            {
                foreach (var compapp in completedApplicationList.OrderByDescending(g => g.DateRecord).Take(1))
                {
                    AppGaugeGraphModel app = new()
                    {
                        DateRecord = compapp.DateRecord,
                      
                        Sum = compapp.Sum
                    };
                    if (compapp.LastSum != 0)
                    {
                        app.Trend = Math.Round(Decimal.Divide(compapp.Sum, compapp.LastSum), 2) * 100;
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
