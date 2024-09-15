using EmployeeManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<LookupResponse>> GetAllAsync();
        Task<bool> IsExists(int id);
    }
}
