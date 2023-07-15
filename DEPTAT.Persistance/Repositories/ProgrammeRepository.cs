using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Persistence.Repositories
{
    public class ProgrammeRepository : GenericRepository<Programme>, IProgrammeRepository
    {
        private readonly DeptatDbContext _dbContext;

        public ProgrammeRepository(DeptatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
