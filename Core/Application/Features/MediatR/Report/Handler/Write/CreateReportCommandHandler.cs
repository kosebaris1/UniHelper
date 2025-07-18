using Application.Features.MediatR.Report.Command;
using Application.Interfaces.ReportInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Report.Handler.Write
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Domain.Entities.Report>(request);
            await _reportRepository.AddAsync(result);
           
        }
    }

}
