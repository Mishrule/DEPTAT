using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Persistence.Repositories
{
    public class DepartmentRepository:GenericRepository<Department>, IDepartmentRepository
    {
        private readonly DeptatDbContext _dbContext;

        public DepartmentRepository(DeptatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
