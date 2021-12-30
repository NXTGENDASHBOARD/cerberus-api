using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationsByInstitutionId
{
    public class GetApplicationsByInstitutionIdQuery : IRequest<IEnumerable<Domain.Models.Application>>
    {
        public int InstitutionId { get; set; }
    }
}
