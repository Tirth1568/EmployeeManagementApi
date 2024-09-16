using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmpTagNumber { get; set; } // Alphanumeric
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public int DesignationId { get; set; }
    }
}
