using EmployeeManagement.Data.Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Repositories
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<LookupResponse>> GetAllAsync();
        Task<bool> IsExists(int id);
    }
}
