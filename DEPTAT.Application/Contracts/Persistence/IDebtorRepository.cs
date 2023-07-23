using DEPTAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Contracts.Persistence
{
    public interface IDebtorRepository : IGenericRepository<Debtors>
    {
    }
}
