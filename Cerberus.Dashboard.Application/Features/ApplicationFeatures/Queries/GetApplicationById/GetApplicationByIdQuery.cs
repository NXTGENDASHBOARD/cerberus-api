using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationById
{
    public class GetApplicationByIdQuery: IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }

    }
}
