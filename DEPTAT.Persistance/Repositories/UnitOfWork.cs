using DEPTAT.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Constants;
using DEPTAT.Application.Profiles;
using DEPTAT.Persistance.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DEPTAT.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DeptatDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
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



        public UnitOfWork(DeptatDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
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
            var userId = _httpContextAccessor.HttpContext.User.Identity.Name;

            var save =  await _context.SaveChangesAsync(userId);
          return save > 0;
        }


    }
}
