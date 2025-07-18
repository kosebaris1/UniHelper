using Application.Features.MediatR.Report.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Report.Queries
{
    public class GetAllReportQuery : IRequest<List<GetAllReportQueryResult>>
    {
    }
}
