using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;

namespace DEPTAT.Application.DTOs.Student
{
    public class UpdateStudentDto:BaseDTO,IStudentDto
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string AcademicYear { get; set; }
        public string ClassYear { get; set; }
        public string AdmittedYear { get; set; }
        public int Level { get; set; }
        public int ProgrammeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
