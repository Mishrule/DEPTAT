using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;
using DEPTAT.Application.DTOs.Department;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.Student
{
    public class StudentDto
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + ", " + FirstName + " " + OtherName;
        public StudentStatus Status { get; set; }
        public string AcademicYear { get; set; }
        public string YearGroup { get; set; }
        public string ClassYear { get; set; }
        public int Level { get; set; }
        public string AdmittedYear { get; set; }
        public int ProgrammeId { get; set; }
        public ProgrammeDto Programme { get; set; }
        public DepartmentDto Department { get; set; }
        public FacultyDto Faculty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
