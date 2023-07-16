using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.Programme
{
    public class CreateProgrammeDto: IProgrammeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
