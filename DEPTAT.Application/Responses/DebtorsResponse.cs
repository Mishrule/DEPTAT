using DEPTAT.Domain.Common;
using DEPTAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.DTOs.Common;
using Semester = DEPTAT.Application.DTOs.Common.Semester;

namespace DEPTAT.Application.Responses
{
    public class DebtorsResponse : BaseDomainEntity
    {
        public string StudentNumber { get; set; }
        public StudentResponse Student { get; set; }
        public Semester Semester { get; set; }
        public string Sem => Semester.ToString();
        public string AcademicYear { get; set; }
        public string PaymentStatus {get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountBilled { get; set; }
        public decimal? Balance { get; set; }
    }
}
