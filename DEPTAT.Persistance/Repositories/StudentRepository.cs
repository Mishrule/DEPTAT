using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Domain.Entities;
using DEPTAT.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Persistence;

namespace DEPTAT.Persistance.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DeptatDbContext _dbContext;
        public StudentRepository(DeptatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
