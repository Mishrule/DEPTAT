using AutoMapper;
using DEPTAT.Application.DTOs.AcademicYear;
using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.DTOs.Department;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.DTOs.YearGroup;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Application.Profiles
{
    public class MappingProfile: Profile
    {
       

        public MappingProfile()
        {
            #region Settings Mapping
            CreateMap<YearGroup, YearGroupDto>().ReverseMap();
            CreateMap<Programme, ProgrammeDto>().ReverseMap();
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<AdmittedClass, AdmittedClassDto>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearDto>().ReverseMap();
            #endregion

        }


    }
}
