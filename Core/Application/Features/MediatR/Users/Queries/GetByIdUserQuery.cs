using Application.Features.MediatR.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Queries
{
    public class GetByIdUserQuery : IRequest<GetByIdUserQueryResult>
    {
        public int Id { get; set; }

        public GetByIdUserQuery(int id)
        {
            Id= id;
        }
    }
}
