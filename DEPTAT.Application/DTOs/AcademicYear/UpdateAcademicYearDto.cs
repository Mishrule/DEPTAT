using DEPTAT.Application.DTOs.Common;

namespace DEPTAT.Application.DTOs.AcademicYear
{
    public class UpdateAcademicYearDto : BaseDTO, IAcademicYearDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
