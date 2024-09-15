using EmployeeManagement.Data.Contexts;
using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly AppDbContext _context;
        public DesignationRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<LookupResponse>> GetAllAsync()
        {
            return await _context.Designations.Where(x => x.IsDeleted != true).Select(i => new LookupResponse
            {
                Id = i.Id,
                Name = i.DesignationName
            })
           .ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Designations.Where(x => x.IsDeleted != true && x.Id == id).AnyAsync();

        }
    }
}
