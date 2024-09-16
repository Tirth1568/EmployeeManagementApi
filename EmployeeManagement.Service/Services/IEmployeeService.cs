using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Models.DTOs;

namespace EmployeeManagement.Service.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int empId);
        Task<EmployeeDTO> CreateEmployeeAsync(Employee employee);
        Task<EmployeeDTO> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int empId);

        Task<PagedResult<EmployeeDTO>> GetEmployeesAsync(int pageIndex, int pageSize, string name = null, string email = null, int? id = null);
    }
}
