using Application.Features.MediatR.Report.Queries;
using Application.Features.MediatR.Report.Result;
using Application.Interfaces.ReportInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Report.Handler.Read
{
    public class GetAllReportQueryHandler : IRequestHandler<GetAllReportQuery, List<GetAllReportQueryResult>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetAllReportQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllReportQueryResult>> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            var result= await _reportRepository.GetAllAsync();
            return _mapper.Map<List<GetAllReportQueryResult>>(result);
        }
    }
}
