using AutoMapper;
using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Models.DTOs;
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
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int empId)
        {
            return await _employeeRepository.GetByIdAsync(empId);
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(Employee employee)
        {
            employee.EmpTagNumber = await GenerateEmpTagNumberAsync(employee.FirstName, employee.LastName);

            var addedEmployee = await _employeeRepository.AddAsync(employee);
            return _mapper.Map<EmployeeDTO>(addedEmployee); // Map Entity to DTO
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(Employee employee)
        {
            var updateEmployee = await _employeeRepository.UpdateAsync(employee);
            return _mapper.Map<EmployeeDTO>(updateEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int empId)
        {
            return await _employeeRepository.DeleteAsync(empId);
        }
        public async Task<PagedResult<EmployeeDTO>> GetEmployeesAsync(int pageIndex, int pageSize, string name = null, string email = null, int? id = null)
        {
            var pagedResult = await _employeeRepository.GetEmployeesAsync(pageIndex, pageSize, name, email, id);
            // Use AutoMapper to map the PagedResult<Employee> to PagedResult<EmployeeDTO>
            var mappedResult = _mapper.Map<PagedResult<EmployeeDTO>>(pagedResult);

            return mappedResult;
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
