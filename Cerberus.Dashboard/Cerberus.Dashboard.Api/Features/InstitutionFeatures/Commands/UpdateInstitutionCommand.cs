using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.InstitutionFeatures.Commands
{
    public class UpdateInstitutionCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; }

        public class UpdateInstitutionCommandHandler : IRequestHandler<UpdateInstitutionCommand, int>
        {
            private readonly IInstitutionService _service;

            public UpdateInstitutionCommandHandler(IInstitutionService service)
            {
                _service = service;
            }
            public async Task<int> Handle(UpdateInstitutionCommand command, CancellationToken cancellationToken)
            {
                var institutionToUpdate = await _service.GetInstitutionByIdAsync(command.Id);
                if (institutionToUpdate == null)
                {
                    return default;
                } else
                {
                    institutionToUpdate.Name = command.Name;
                    institutionToUpdate.Region = command.Region;
                    institutionToUpdate.IsMainCampus = command.IsMainCampus;
                    institutionToUpdate.Province = command.Province;
                    institutionToUpdate.PostCode = command.PostCode;
                    institutionToUpdate.ModifyDate = System.DateTime.UtcNow.ToLocalTime();
                    institutionToUpdate.ModifyUserId = command.ModifyUserId;
                    institutionToUpdate.IsActive = command.IsActive;

                    return await _service.UpdateInstitutionAsync(institutionToUpdate);
                }
            }
        }
    }
}
