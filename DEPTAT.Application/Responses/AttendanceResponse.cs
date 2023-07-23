﻿using DEPTAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Common;

namespace DEPTAT.Application.Responses
{
	public class AttendanceResponse
	{
		public int Id { get; set; }
		public string StudentNumber { get; set; }
		public Student Student { get; set; }
		public string AnswerBookSerialNumber { get; set; }
		public Semester Semester { get; set; }
		public string CourseCode { get; set; }
		public string AcademicYear { get; set; }
		public string OtpCode { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
