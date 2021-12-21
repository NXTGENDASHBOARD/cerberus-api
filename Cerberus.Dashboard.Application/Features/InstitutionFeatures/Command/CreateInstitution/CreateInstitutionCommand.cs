using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.CreateInstitution
{
    public class CreateInstitutionCommand : IRequest<int>
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
        public int StatusId { get; set; }
    }
}
