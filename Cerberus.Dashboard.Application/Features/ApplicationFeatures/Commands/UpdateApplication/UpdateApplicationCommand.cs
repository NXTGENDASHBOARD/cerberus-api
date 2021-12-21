using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.UpdateApplication
{
    public class UpdateApplicationCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string ApplicationDate { get; set; }
        public bool IsDisable { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }
    }
}
