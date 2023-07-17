using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.Responses
{
    public class DepartmentResponse:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
        public FacultyResponse Faculty { get; set; }
    }
}
