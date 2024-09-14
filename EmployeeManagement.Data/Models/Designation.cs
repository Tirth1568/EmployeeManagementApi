

using EmployeeManagement.Data.Models.Common;

namespace EmployeeManagement.Data.Models
{
    public class Designation: BaseOptionalActorEntity
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        // Navigation property for related employees
        public ICollection<Employee> Employees { get; set; }
    }
}
