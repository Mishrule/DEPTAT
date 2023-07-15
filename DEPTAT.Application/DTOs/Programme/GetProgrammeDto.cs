using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Programme
{
    public class GetProgrammeDto:BaseDomainEntity, IProgrammeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
