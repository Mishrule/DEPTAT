using DEPTAT.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Constants;

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

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

          var save =  await _context.SaveChangesAsync(username);
          return save > 0;
        }

        //public async Task<bool> Save(HttpContext httpContext)
        //{
        //    var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var user = await _userManager.FindByEmailAsync(userId);

        //    var entries = _context.ChangeTracker.Entries()
        //        .Where(q => q.State == EntityState.Modified ||
        //                    q.State == EntityState.Added);

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Modified)
        //        {
        //            ((EntityBase)entry.Entity).ModifiedDate = DateTime.Now;
        //            ((EntityBase)entry.Entity).ModifiedBy = user?.UserName;
        //        }
        //        else if (entry.State == EntityState.Added)
        //        {
        //            ((EntityBase)entry.Entity).CreatedDate = DateTime.Now;
        //            ((EntityBase)entry.Entity).CreatedBy = user?.UserName;
        //        }
        //    }



        //    var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
        //    var changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}


    }
}
