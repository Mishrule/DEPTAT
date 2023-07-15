using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Course
{
    public class GetCourseDto:BaseDomainEntity, ICourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int ProgrammeId { get; set; }
    }
}
