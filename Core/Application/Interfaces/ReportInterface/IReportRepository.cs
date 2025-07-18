using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterface
{
    public interface IReportRepository
    {
        Task AddAsync(Report report);
        Task<List<Report>> GetAllAsync();
        Task<List<Report>> GetReportsByAnswerAsync(int answerId);

    }
}
