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
    public class GetReportByAnswerIdQueryHandler : IRequestHandler<GetReportByAnswerIdQuery, List<GetReportByAnswerIdQueryResult>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        public GetReportByAnswerIdQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<List<GetReportByAnswerIdQueryResult>> Handle(GetReportByAnswerIdQuery request, CancellationToken cancellationToken)
        {
           var values= await _reportRepository.GetReportsByAnswerAsync(request.Id);
            return _mapper.Map<List<GetReportByAnswerIdQueryResult>>(values);
        }
    }
}
