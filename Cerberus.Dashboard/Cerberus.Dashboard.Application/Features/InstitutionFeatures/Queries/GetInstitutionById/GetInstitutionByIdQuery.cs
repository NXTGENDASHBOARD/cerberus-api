﻿using Cerberus.Dashboard.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetInstitutionById
{
    public class GetInstitutionByIdQuery : IRequest<Institution>
    {
        public int Id { get; set; }
    }
}
