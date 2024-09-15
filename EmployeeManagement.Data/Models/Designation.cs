

using EmployeeManagement.Data.Models.Common;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Data.Models
{
    public class Designation: BaseOptionalActorEntity
    {
        public string DesignationName { get; set; }

        // Navigation property for related employees
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
