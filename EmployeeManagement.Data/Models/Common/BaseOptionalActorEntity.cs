using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Models.Common
{
    public abstract class BaseOptionalActorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DeletedAt { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public int? DeletedById { get; set; }
        public bool IsDeleted { get; set; }
    }
}
