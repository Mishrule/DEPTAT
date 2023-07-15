using DEPTAT.Domain.Common;

namespace DEPTAT.Application.DTOs.AcademicYear
{
    public class GetAcademicYearDto:BaseDomainEntity, IAcademicYearDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
