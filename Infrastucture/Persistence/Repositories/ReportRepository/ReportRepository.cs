using Application.Interfaces.ReportInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        private readonly UniHelperContext _context;

        public ReportRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await _context.Reports
                .Include(r => r.User)
                .Include(r => r.Question)
                .Include(r => r.Answer)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Report>> GetReportsByAnswerAsync(int answerId)
        {
            return await _context.Reports
        .Where(r => r.AnswerId == answerId)
        .Include(r => r.User)
        .Include(r => r.Question)
        .Include(r => r.Answer)
        .OrderByDescending(r => r.CreatedAt)
        .ToListAsync();
        }
    }
}
