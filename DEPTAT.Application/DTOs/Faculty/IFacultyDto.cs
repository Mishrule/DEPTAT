using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.Faculty
{
    public interface IFacultyDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
