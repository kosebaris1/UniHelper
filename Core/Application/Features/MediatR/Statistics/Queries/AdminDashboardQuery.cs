using Application.Features.MediatR.Statistics.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Statistics.Queries
{
    public class AdminDashboardQuery:IRequest<AdminDashboardQueryResult>
    {
    }
}
