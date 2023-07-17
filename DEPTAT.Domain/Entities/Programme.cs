using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Domain.Entities
{
    public class Programme:BaseDomainEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get;set; }
        public Department Department { get; set; }
    }
}
