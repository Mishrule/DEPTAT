using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Constants;
using DEPTAT.Application.Profiles;
using DEPTAT.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DEPTAT.Persistence
{
    public abstract class AuditableDbContext : IdentityDbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
