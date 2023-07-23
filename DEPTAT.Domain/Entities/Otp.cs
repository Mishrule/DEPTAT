using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Domain.Entities
{

	public class Otp
	{
		[Key]
		public int Id { get; set; }
		public string OtpCode { get; set; }
		[ForeignKey(nameof(Student))]
		public string StudentNumber { get; set; }
		public Student Student { get; set; }
		public int CurrentYear { get; set; }
	}
}
