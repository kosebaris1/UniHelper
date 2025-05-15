﻿using Application.Features.MediatR.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Queries
{
    public class GetByIdUserDetailsForAdminQuery : IRequest<GetByIdUserDetailsForAdminQueryResult>
    {
        public int Id { get; set; }

        public GetByIdUserDetailsForAdminQuery(int id)
        {
            Id = id;
        }
    }
}
