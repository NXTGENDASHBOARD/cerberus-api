using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.DeleteInstitution
{
    public class DeleteInstitutionByIdCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
