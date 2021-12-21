using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.InstitutionFeatures.Commands
{
    public class CreateInstitutionCommand: IRequest<int>
    { 
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; }

        public class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, int>
        {
            private readonly IInstitutionService _service;

            public CreateInstitutionCommandHandler(IInstitutionService service)
            {
                _service = service;
            }
            public async Task<int> Handle(CreateInstitutionCommand command, CancellationToken cancellationToken)
            {
                var institution = new Institution(); 

                institution.Name = command.Name;    
                institution.Region = command.Region;
                institution.IsMainCampus=   command.IsMainCampus;
                institution.Province = command.Province;
                institution.PostCode = command.PostCode;
                institution.CreateUserId = command.CreateUserId;
                institution.CreatedDate = DateTime.UtcNow.ToLocalTime();
                institution.ModifyUserId = command.ModifyUserId;
                institution.ModifyDate = DateTime.UtcNow.ToLocalTime();
                institution.IsActive = command.IsActive;

                return await _service.CreateInstitutionAsync(institution);

            }
        }
    }
}
