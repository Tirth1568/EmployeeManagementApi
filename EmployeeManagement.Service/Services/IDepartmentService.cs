using EmployeeManagement.Data.Models;

namespace EmployeeManagement.Service.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<LookupResponse>> GetDepartmentsAsync();
        Task<bool> IsExists(int id);
    }
}
