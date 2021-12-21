using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.UpdateInstitution
{
    public class UpdateInstitutionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }   
    }
}
