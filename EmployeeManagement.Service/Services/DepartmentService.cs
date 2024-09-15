using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<LookupResponse>> GetDepartmentsAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _departmentRepository.IsExists(id);

        }
    }
}
