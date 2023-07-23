using DEPTAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Responses
{
	public class OtpResponse
	{
		public int Id { get; set; }
		public string OtpCode { get; set; }
		public string StudentNumber { get; set; }
		public StudentResponse Student { get; set; }
		public int CurrentYear { get; set; }
	}
}
