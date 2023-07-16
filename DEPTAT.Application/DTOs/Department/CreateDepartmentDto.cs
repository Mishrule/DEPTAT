using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.Department
{
    public class CreateDepartmentDto: IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
