using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.DTOs.Student
{
    public class CreateStudentDto : IStudentDto
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string AcademicYear { get; set; }
        public string ClassYear { get; set; }
        public string AdmittedYear { get; set; }
        public int ProgrammeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
