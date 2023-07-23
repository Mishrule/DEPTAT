using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Infrastructure.Excel;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Application.Responses;
using DEPTAT.Persistance.Repositories;
using DEPTAT.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DEPTAT.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeptatDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IYearGroupRepository, YearGroupRepository>();
            services.AddScoped<IProgrammeRepository, ProgrammeRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAdmittedClassRepository, AdmittedClassRepository>();
            services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDebtorRepository, DebtorRepository>();
            services.AddScoped<ILoadExcelToDb<DebtorsResponse>, LoadExcelToDb>();
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            return services;
        }
    }
}
