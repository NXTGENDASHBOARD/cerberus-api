using Cerberus.Dashboard.Application.Services.ITS;
using Cerberus.Dashboard.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetAllInstitutionsFromITS
{
    public class GetAllInstitutionsFromITSQueryHandler : IRequestHandler<GetAllInstitutionsFromITSQuery, IEnumerable<Institution>>
    {
        private readonly IITS_InstitutionService _institutionService;
        public GetAllInstitutionsFromITSQueryHandler(IITS_InstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        public async Task<IEnumerable<Institution>> Handle(GetAllInstitutionsFromITSQuery request, CancellationToken cancellationToken)
        {
            await _institutionService.getInstitutions();
            return null;
        }
    }
}
