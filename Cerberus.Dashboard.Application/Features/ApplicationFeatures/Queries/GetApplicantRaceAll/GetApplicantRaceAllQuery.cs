using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantRaceAll
{
    public class GetApplicantRaceAllQuery : IRequest<IEnumerable<Domain.Models.RaceGraphModel>>
    {
        public bool isPaginated { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}
