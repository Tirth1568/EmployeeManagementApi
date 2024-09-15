using EmployeeManagement.Data.Models;

namespace EmployeeManagement.Service.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int empId);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int empId);

        Task<PagedResult<Employee>> GetEmployeesAsync(int pageIndex, int pageSize, string name = null, string email = null, int? id = null);
    }
}
