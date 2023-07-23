using DEPTAT.Application.Contracts.Persistence;
using DEPTAT.Domain.Entities;
using DEPTAT.Persistence.Repositories;
using DEPTAT.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Persistance.Repositories
{
    public class DebtorRepository : GenericRepository<Debtors>, IDebtorRepository
    {
        private readonly DeptatDbContext _dbContext;

        public DebtorRepository(DeptatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
