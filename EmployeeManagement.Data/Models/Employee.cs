using EmployeeManagement.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models
{
    public class Employee : BaseOptionalActorEntity
    {

        public string EmpTagNumber { get; set; } // Alphanumeric
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        // Foreign Key for Department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; } // Navigation Property
        [ForeignKey("Designation")]
        // Foreign Key for Designation
        [Required]
        public int DesignationId { get; set; }
        [JsonIgnore]
        public Designation Designation { get; set; } // Navigation Property


        // Calculated Age property
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--; // Adjust if the birthday hasn't occurred yet this year
                return age;
            }
        }
    }
}
