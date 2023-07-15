using DEPTAT.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Responses
{
    public class AcademicYearResponse : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
