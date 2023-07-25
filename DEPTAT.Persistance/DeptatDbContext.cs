using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Profiles;
using DEPTAT.Domain.Entities;
using DEPTAT.Persistance.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DEPTAT.Domain.Common;

namespace DEPTAT.Persistence
{
   // public class DeptatDbContext : IdentityDbContext
    public class DeptatDbContext : AuditableDbContext
    {
        public DeptatDbContext(DbContextOptions<DeptatDbContext> options) : base(options) { }

        

        public DbSet<YearGroup> YearGroups { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<AdmittedClass> AdmittedClasses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Debtors> Debtors { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            //builder.ApplyConfigurationsFromAssembly(typeof(DeptatDbContext).Assembly);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedingConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging for more detailed information in logs
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
