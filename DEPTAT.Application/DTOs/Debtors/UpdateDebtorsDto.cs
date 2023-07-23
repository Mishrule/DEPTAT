using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;
using DEPTAT.Application.DTOs.Student;

namespace DEPTAT.Application.DTOs.Debtors
{
    public class UpdateDebtorsDto: IDebtorsDto
    {
        public string StudentNumber { get; set; }
        //public StudentDto Student { get; set; }
        //public Semester Semester { get; set; }
        //public string AcademicYear { get; set; }
        public string PaymentStatus { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountBilled { get; set; }
        public decimal? Balance { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
      
    }
}
