using Application.Interfaces.DepartmentInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UniHelperContext _context;

        public DepartmentRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDistinctDepartmentsAsync()
        {
            return await _context.Departments
           .Where(x=>x.DeletedDate==null)
           .GroupBy(d => d.Name)
           .Select(g => g.First())
           .ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentsByUniversity(int id)
        {
            var entity = await _context.Departments
               .Where(p => p.UniversityId == id && p.DeletedDate == null)
               .ToListAsync();

            if (entity == null)
                throw new Exception("Departman bulunamadı.");
            return entity;
        }
    }
}
