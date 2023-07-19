using AutoMapper;
using DEPTAT.Application.DTOs.AcademicYear;
using DEPTAT.Application.DTOs.AdmittedClass;
using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.DTOs.Department;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.DTOs.Student;
using DEPTAT.Application.DTOs.YearGroup;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Application.Profiles
{
    public class MappingProfile: Profile
    {
       

        public MappingProfile()
        {
            #region Settings Mapping
            CreateMap<YearGroup, YearGroupDto>().ReverseMap();
			CreateMap<YearGroup, CreateYearGroupDto>().ReverseMap();
			CreateMap<YearGroup, YearGroupResponse>().ReverseMap();
			CreateMap<YearGroup, UpdateYearGroupDto>().ReverseMap();


			CreateMap<AcademicYear, AcademicYearDto>().ReverseMap();
			CreateMap<AcademicYear, CreateAcademicYearDto>().ReverseMap();
			CreateMap<AcademicYear, AcademicYearResponse>().ReverseMap();
			CreateMap<AcademicYear, UpdateAcademicYearDto>().ReverseMap();

			CreateMap<Faculty, FacultyDto>().ReverseMap();
			CreateMap<Faculty, CreateFacultyDto>().ReverseMap();
			CreateMap<Faculty, FacultyResponse>().ReverseMap();
			CreateMap<Faculty, UpdateFacultyDto>().ReverseMap();

			CreateMap<Department, DepartmentDto>().ReverseMap();
			CreateMap<Department, CreateDepartmentDto>().ReverseMap();
			CreateMap<Department, DepartmentResponse>().ReverseMap();
			CreateMap<Department, UpdateDepartmentDto>().ReverseMap();

			CreateMap<Programme, ProgrammeDto>().ReverseMap();
			CreateMap<Programme, CreateProgrammeDto>().ReverseMap();
			CreateMap<Programme, ProgrammeResponse>().ReverseMap();
			CreateMap<Programme, UpdateProgrammeDto>().ReverseMap();


			CreateMap<Course, CourseDto>().ReverseMap();
			CreateMap<Course, CreateCourseDto>().ReverseMap();
			CreateMap<Course, CourseResponse>().ReverseMap();
			CreateMap<Course, UpdateCourseDto>().ReverseMap();





			CreateMap<AdmittedClass, AdmittedClassDto>().ReverseMap();
			#endregion


			#region Students
			CreateMap<Student, StudentDto>().ReverseMap();
			CreateMap<Student, CreateStudentDto>().ReverseMap();
			CreateMap<Student, StudentResponse>().ReverseMap();
			CreateMap<Student, UpdateStudentDto>().ReverseMap();


			#endregion
		}


    }
}
