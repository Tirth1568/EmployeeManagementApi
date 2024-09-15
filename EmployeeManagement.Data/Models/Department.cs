using EmployeeManagement.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models
{
    public class Department : BaseOptionalActorEntity
    {
        public string DepartmentName { get; set; }

        // Navigation property for related employees
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
