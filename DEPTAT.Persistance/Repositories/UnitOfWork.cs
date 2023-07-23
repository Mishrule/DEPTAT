using DEPTAT.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Constants;
using DEPTAT.Persistance.Repositories;

namespace DEPTAT.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DeptatDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IYearGroupRepository? _yearGroupRepository;
        private IAcademicYearRepository _academicYearRepository;
        private IAdmittedClassRepository _admittedClassRepository;
        private IFacultyRepository _facultyRepository;
        private IDepartmentRepository _departmentRepository;
        private IProgrammeRepository _programmeRepository;
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentRepository;
        private IDebtorRepository _debtorRepository;
        private IOtpRepository _otpRepository;
        private IAttendanceRepository _attendanceRepository;



        public UnitOfWork(DeptatDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IYearGroupRepository YearGroupRepository => _yearGroupRepository ??= new YearGroupRepository(_context);
        public IAcademicYearRepository AcademicYearRepository => _academicYearRepository ??= new AcademicYearRepository(_context);
        public IAdmittedClassRepository AdmittedClassRepository => _admittedClassRepository ??= new AdmittedClassRepository(_context);
        public IFacultyRepository FacultyRepository => _facultyRepository ??= new FacultyRepository(_context);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_context);
        public IProgrammeRepository ProgrammeRepository => _programmeRepository ??= new ProgrammeRepository(_context);
        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_context);
        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);
        public IDebtorRepository DebtorRepository => _debtorRepository ??= new DebtorRepository(_context);
        public IOtpRepository OtpRepository => _otpRepository ??= new OtpRepository(_context);
        public IAttendanceRepository AttendanceRepository => _attendanceRepository ??= new AttendanceRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

          var save =  await _context.SaveChangesAsync();
          return save > 0;
        }

        

    }
}
