using Domain.Entities;

namespace Application.Interfaces.DepartmentInterface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsByUniversity(int id);

        Task<List<Department>> GetAllDistinctDepartmentsAsync();

    }
}
