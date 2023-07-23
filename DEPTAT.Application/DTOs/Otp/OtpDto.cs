using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Student;

namespace DEPTAT.Application.DTOs.Otp
{
	public class OtpDto
	{
		public int Id { get; set; }
		public string OtpCode { get; set; }
		public string StudentNumber { get; set; }
		//public StudentDto Student { get; set; }
		public int CurrentYear { get; set; }
	}
}
