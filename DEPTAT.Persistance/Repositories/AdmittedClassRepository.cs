using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Persistence.Repositories
{
    public class AdmittedClassRepository:GenericRepository<AdmittedClass>, IAdmittedClassRepository
    {
        private readonly DeptatDbContext _dbContext;

        public AdmittedClassRepository(DeptatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
