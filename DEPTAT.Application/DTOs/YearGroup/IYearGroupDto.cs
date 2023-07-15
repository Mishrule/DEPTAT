using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.YearGroup
{
    public interface IYearGroupDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
