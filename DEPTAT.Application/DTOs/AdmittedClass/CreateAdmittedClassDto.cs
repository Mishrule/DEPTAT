using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.AdmittedClass
{
    public class CreateAdmittedClassDto: IAdmittedClassDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
