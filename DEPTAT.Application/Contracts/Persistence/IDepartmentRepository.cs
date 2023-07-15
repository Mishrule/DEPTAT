using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Domain.Entities;

namespace DEPTAT.Application.Contracts.Persistence
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
    }
}
