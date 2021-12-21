using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.Account.Queries.VerifyAccount
{
    public class VerifyAccountQuery : IRequest<int>
    {
        public string StaffNumber { get; set; }
        public int Pin { get; set; }
    }
}
