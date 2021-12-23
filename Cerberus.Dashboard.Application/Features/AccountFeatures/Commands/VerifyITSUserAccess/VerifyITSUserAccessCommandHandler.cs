using Cerberus.Dashboard.Application.Services.ITS;
using Cerberus.Dashboard.Domain.ITSModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Commands.VerifyITSUserAccess
{
    public class VerifyITSUserAccessCommandHandler : IRequestHandler<VerifyITSUserAccessCommand, UserAccessResponseModel>
    {
        private readonly IITS_SecurityService _service;

        public VerifyITSUserAccessCommandHandler(IITS_SecurityService service)
        {
            _service = service;
        }

        public async Task<UserAccessResponseModel> Handle(VerifyITSUserAccessCommand query, CancellationToken cancellationToken)
        {
            // TODO generate token based on command inputs (StaffNumber & Pin)
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im9sbGllLm9sd2FnZUBhZGFwdGl0LmNvbSIsInVzZXJpZCI6Ik9MTElFIiwic3RhZmZudW1iZXIiOiIxIiwicGFzc3dvcmQiOiI3YjJjYWI2N2MyYzcwY2Y3ZjY5OWNhODllZmE2ZWY4NzU2Zjg0NmQ3MmM2Y2I4ZTBiYmYyN2VhZWFlZmI4Y2JlIiwicm9sIjoiUGVyc29ubmVsIiwiaWF0IjoiMTYzOTU4OTI2NiJ9._teY4-ZWr9KzsB7MPLlkynRHARFNr0_fGsZC4SGmAXI";
            var user = await _service.verifyUserAccess(token);
            if(user == null) return null;
            return user;
        }
    }
}
