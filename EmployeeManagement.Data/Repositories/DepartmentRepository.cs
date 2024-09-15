using EmployeeManagement.Data.Contexts;
using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EmployeeManagement.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;

        }
        public async Task<IEnumerable<LookupResponse>> GetAllAsync()
        {
            return await _context.Departments.Where(x => x.IsDeleted != true).Select(i => new LookupResponse
            {
                Id = i.Id,
                Name = i.DepartmentName
            })
            .ToListAsync();
        }

        public async Task<bool> IsExists (int id)
        {
            return await _context.Departments.Where(x => x.IsDeleted != true && x.Id == id).AnyAsync();

        }
    }
}
