using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.YearGroup
{
    public class CreateYearGroupDto : IYearGroupDto
    {
        public int Name { get; set; }
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
