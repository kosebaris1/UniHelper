using Application.Features.MediatR.Cities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Cities.Queries
{
    public class GetAllCityQuery:IRequest<List<GetAllCityQueryResult>>
    {
    }
}
