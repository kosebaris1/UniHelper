using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UniversitiesInterface
{
    public interface IUniversitiesRepository
    {
        Task<List<University>> GetAllUniversityAsync();
    }
}
