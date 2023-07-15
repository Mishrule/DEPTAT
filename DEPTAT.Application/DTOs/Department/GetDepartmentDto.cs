using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Department
{
    public class GetDepartmentDto: BaseDomainEntity, IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
    }
}
