using Application.Features.MediatR.Statistics.Queries;
using Application.Features.MediatR.Statistics.Results;
using Application.Interfaces;
using Application.Interfaces.StatisticInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Statistics.Handlers
{
    public class AdminDashboardQueryHandler : IRequestHandler<AdminDashboardQuery, AdminDashboardQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public AdminDashboardQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<AdminDashboardQueryResult> Handle(AdminDashboardQuery request, CancellationToken cancellationToken)
        {
            return await _statisticRepository.GetDashboardDataAsync();
        }
    }
}
