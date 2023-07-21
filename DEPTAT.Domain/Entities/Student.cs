using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Domain.Entities
{
	public class Student : BaseDomainEntity
	{
		public string IndexNumber { get; set; }
		public string FirstName { get; set; }
		public string OtherName { get; set; }
		public string LastName { get; set; }
		public string FullName => LastName + ", " + FirstName + " " + OtherName;
		public int Status { get; set; }
		public string AcademicYear { get; set; }
		public int YearGroup { get; set; }
		public int Level { get; set; }
		public string ClassYear { get; set; }
		public string AdmittedYear { get; set; }
		public int ProgrammeId { get; set; }
		public Programme Programme { get; set; }
		//public Department Department { get; set; }
		//public Faculty Faculty { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string? ImageUrl { get; set; }
	}
}
