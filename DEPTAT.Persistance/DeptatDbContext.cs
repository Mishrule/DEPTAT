using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Persistence
{
    public class DeptatDbContext : AuditableDbContext
    {
        public DeptatDbContext(DbContextOptions<DeptatDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeptatDbContext).Assembly);
        }

        public DbSet<YearGroup> YearGroups { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<AdmittedClass> AdmittedClasses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
