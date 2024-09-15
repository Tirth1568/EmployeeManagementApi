using EmployeeManagement.Data.Models;


namespace EmployeeManagement.Service.Services
{
    public interface IDesignationService
    {
        Task<IEnumerable<LookupResponse>> GetDesignationsAsync();
        Task<bool> IsExists(int id);
    }



}
