using EmployeeManagement.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models
{
    public class Department : BaseOptionalActorEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation property for related employees
        public ICollection<Employee> Employees { get; set; }
    }
}
