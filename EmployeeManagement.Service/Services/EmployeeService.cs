using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int empId)
        {
            return await _employeeRepository.GetByIdAsync(empId);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            employee.EmpTagNumber = await GenerateEmpTagNumberAsync(employee.FirstName, employee.LastName);

            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int empId)
        {
            return await _employeeRepository.DeleteAsync(empId);
        }
        public Task<PagedResult<Employee>> GetEmployeesAsync(int pageIndex, int pageSize, string name = null, string email = null, int? id = null)
        {
            return _employeeRepository.GetEmployeesAsync(pageIndex, pageSize, name, email, id);
        }

        public async Task<string> GenerateEmpTagNumberAsync(string firstName, string lastName)
        {
            // Step 1: Get the first 2 letters of the first and last name
            var firstPart = (firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName).ToUpper();
            var secondPart = (lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName).ToUpper();

            // Step 2: Get the current highest sequential number in the database (e.g., "JOHNSM01")
            var lastEmpTag = await _employeeRepository.GetLastEmployeeTagAsync();

            int nextSequentialNumber = 1; // Default start value

            if (!string.IsNullOrEmpty(lastEmpTag))
            {
                // Extract the numeric part of the last generated EmpTag
                var numericPart = new string(lastEmpTag.Where(char.IsDigit).ToArray());
                if (int.TryParse(numericPart, out int lastSequentialNumber))
                {
                    nextSequentialNumber = lastSequentialNumber + 1;
                }
            }

            // Step 3: Construct the new EmpTagNumber
            string empTagNumber = $"{firstPart}{secondPart}{nextSequentialNumber:D2}"; // Format it as two digits (e.g., 01, 02, etc.)

            return empTagNumber;
        }
    }
}
