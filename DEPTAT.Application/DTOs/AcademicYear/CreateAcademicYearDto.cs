namespace DEPTAT.Application.DTOs.AcademicYear
{
    public class CreateAcademicYearDto: IAcademicYearDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
