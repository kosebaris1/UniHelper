﻿using Application.Features.MediatR.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Queries
{
    public class GetAllUserQuery : IRequest<List<GetAllUserQueryResult>>
    {
    }
}
