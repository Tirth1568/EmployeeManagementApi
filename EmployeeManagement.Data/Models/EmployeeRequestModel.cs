using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        [Required]
        public int DepartmentId { get; set;}
        [Required]
        public int DesignationId { get; set;}

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
