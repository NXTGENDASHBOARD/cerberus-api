using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetAllApplications
{
    public class GetAllApplicationsQuery: IRequest<IEnumerable<Domain.Models.Application>>
    {
    }
}
