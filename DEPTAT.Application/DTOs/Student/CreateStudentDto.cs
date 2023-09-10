using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Programme;
using Microsoft.AspNetCore.Http;

namespace DEPTAT.Application.DTOs.Student
{
    public class CreateStudentDto : IStudentDto
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string AcademicYear { get; set; }
        public string ClassYear { get; set; }
        public int YearGroup { get; set; }
        public string AdmittedYear { get; set; }
        public IFormFile File { get; set; }
        //public int Level { get; set; }
        public int ProgrammeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
