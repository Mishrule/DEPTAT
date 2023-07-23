using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;
using DEPTAT.Application.DTOs.Student;
using Microsoft.AspNetCore.Http;

namespace DEPTAT.Application.DTOs.Debtors
{
    public class CreateDebtorsDto : IDebtorsDto
    {
        public string StudentNumber { get; set; }
        public Semester Semester { get; set; }
        public string AcademicYear { get; set; }
        public string PaymentStatus { get; set; }
        public IFormFile File { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountBilled { get; set; }
        public decimal? Balance { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
