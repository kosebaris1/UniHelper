using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<GetAllUserQueryResult>>
    {
        public Task<List<GetAllUserQueryResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
