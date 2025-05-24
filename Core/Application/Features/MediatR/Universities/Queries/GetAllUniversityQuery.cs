using Application.Features.MediatR.Universities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Universities.Queries
{
    public class GetAllUniversityQuery : IRequest<List<GetAllUniversityQueryResult>>
    {

    }
}
