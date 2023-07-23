using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Domain.Common;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Application.Responses
{
    public class StudentResponse
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + ", " + FirstName + " " + OtherName;
        public StudentStatus Status { get; set; }
        public string AcademicYear { get; set; }
        public string ClassYear { get; set; }
        public int YearGroup { get; set; }
        public int Level { get; set; }
        public string AdmittedYear { get; set; }
        public int ProgrammeId { get; set; }
        public ProgrammeResponse Programme { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
