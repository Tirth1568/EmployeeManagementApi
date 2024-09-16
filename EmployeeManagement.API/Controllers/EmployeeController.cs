using EmployeeManagement.Data.Models;
using EmployeeManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService , IDesignationService designationService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _designationService = designationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string name = null,
        [FromQuery] string email = null,
        [FromQuery] int? id = null)
        {
            var result = await _employeeService.GetEmployeesAsync(pageIndex, pageSize, name, email, id);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeRequestModel employeeRM)
        {
            if (employeeRM == null) return BadRequest();
            if (! await _designationService.IsExists(employeeRM.DesignationId)) return BadRequest();
            if (! await _departmentService.IsExists(employeeRM.DepartmentId)) return BadRequest();
            Employee employee = new Employee() { 
                FirstName = employeeRM.FirstName,
                LastName = employeeRM.LastName,
                Email = employeeRM.Email,
                BirthDate = employeeRM.BirthDate,
                DepartmentId = employeeRM.DepartmentId,
                DesignationId = employeeRM.DesignationId
            };

            var newEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRequestModel employeeRM)
        {
            if (id != employeeRM.Id)
            {
                return BadRequest();
            }
            var existingEntry = await _employeeService.GetEmployeeByIdAsync(id);
            if(existingEntry == null) { return BadRequest(); }

            existingEntry.FirstName = employeeRM.FirstName;
            existingEntry.LastName = employeeRM.LastName;
            existingEntry.Email = employeeRM.Email;
            existingEntry.BirthDate = employeeRM.BirthDate;
            existingEntry.DepartmentId = employeeRM.DepartmentId;
            existingEntry.DesignationId = employeeRM.DesignationId;
     
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(existingEntry);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
