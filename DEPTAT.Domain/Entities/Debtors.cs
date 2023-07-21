using DEPTAT.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Domain.Entities
{
    public class Debtors : BaseDomainEntity
    {
        public string StudentNumber { get; set; }
        public string Semester { get; set; }
        public string AcademicYear { get; set; }
        public string PaymentStatus { get; set; }
        public string AmountPaid { get; set; }
        public string AmountBilled { get; set; }
    }
}
