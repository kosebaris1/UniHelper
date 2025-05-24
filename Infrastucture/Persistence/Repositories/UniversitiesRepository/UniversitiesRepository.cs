using Application.Interfaces.UniversitiesInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UniversitiesRepository
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly UniHelperContext _uniHelperContext;

        public UniversitiesRepository(UniHelperContext uniHelperContext)
        {
            _uniHelperContext = uniHelperContext;
        }

        public async Task<List<University>> GetAllUniversityAsync()
        {
            return await _uniHelperContext.Universitites.Where(x => x.DeletedDate == null).ToListAsync();

        }
    }
}
