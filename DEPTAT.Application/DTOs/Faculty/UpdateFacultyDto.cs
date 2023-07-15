using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;

namespace DEPTAT.Application.DTOs.Faculty
{
    public class UpdateFacultyDto:BaseDTO, IFacultyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
