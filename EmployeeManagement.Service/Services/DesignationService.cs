using EmployeeManagement.Data.Models;
using EmployeeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _designationRepository;
        public DesignationService(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<IEnumerable<LookupResponse>> GetDesignationsAsync()
        {
            return await _designationRepository.GetAllAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _designationRepository.IsExists(id);

        }

    }
}
