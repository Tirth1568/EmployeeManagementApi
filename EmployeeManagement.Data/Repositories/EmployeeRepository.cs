using EmployeeManagement.Data.Contexts;
using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int empId)
        {
            return await _context.Employees.FindAsync(empId);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            if (employee.Department != null)
            {
                var department = await _context.Departments
                    .FindAsync(employee.Department.Id);
                if (department != null)
                {
                    employee.Department = department;
                }
            }

            // Retrieve existing Designation if it is provided
            if (employee.Designation != null)
            {
                var designation = await _context.Designations
                    .FindAsync(employee.Designation.Id);
                if (designation != null)
                {
                    employee.Designation = designation;
                }
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return await _context.Employees
       .Include(e => e.Department)
       .Include(e => e.Designation)
       .FirstOrDefaultAsync(e => e.Id == employee.Id);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            employee.UpdatedAt = DateTimeOffset.UtcNow;
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();
            return await _context.Set<Employee>().AsQueryable()
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(x => x.Id == employee.Id);

        }

        public async Task<bool> DeleteAsync(int empId)
        {
            var employee = await _context.Employees.FindAsync(empId);
            if (employee == null)
            {
                return false;
            }

            employee.DeletedAt = DateTime.UtcNow;
            employee.IsDeleted = true;
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PagedResult<Employee>> GetEmployeesAsync(int pageIndex, int pageSize, string name = null, string email = null, int? id = null)
        {
            var query = _context.Employees.Where(x => x.IsDeleted != true).AsQueryable();

            // Apply filters
            if (id.HasValue)
            {
                query = query.Where(e => e.Id == id.Value);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(e => e.Email.Contains(email));
            }

            // Apply pagination
            var totalRecords = await query.CountAsync();
            var employees = await query
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated result
            return new PagedResult<Employee>
            {
                TotalRecords = totalRecords,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Records = employees
            };
        }

        public async Task<string> GetLastEmployeeTagAsync()
        {
            var lastEmployee = await _context.Employees
                .OrderByDescending(e => e.EmpTagNumber)
                .FirstOrDefaultAsync();

            return lastEmployee?.EmpTagNumber;
        }
    }
}
