using DEPTAT.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Domain.Entities
{
    public class Debtors : BaseDomainEntity
    {
        [ForeignKey(nameof(Student))]
        public string StudentNumber { get; set; }
        public Student Student { get; set; }
        public Semester Semester { get; set; }
        public string AcademicYear { get; set; }
        public string PaymentStatus { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountBilled { get; set; }
        public decimal? Balance { get; set; }
    }
}
