using Application.Features.MediatR.Statistics.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.StatisticInterface
{
    public interface IStatisticRepository
    {
        Task<AdminDashboardQueryResult> GetDashboardDataAsync();

    }
}
