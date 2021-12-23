using Cerberus.Dashboard.Domain.ITSModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Commands.VerifyITSUserAccess
{
    public class VerifyITSUserAccessCommand: IRequest<UserAccessResponseModel>
    {
        [Required]
        public string StaffNumber { get; set; }

        [Required]
        public int Pin { get; set; }
    }
}
