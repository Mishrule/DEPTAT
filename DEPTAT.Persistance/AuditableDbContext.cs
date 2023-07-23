using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPTAT.Application.Profiles;
using DEPTAT.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DEPTAT.Persistence
{
    public abstract class AuditableDbContext : IdentityDbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {

            //public async Task<bool> Save(HttpContext httpContext)
            //{
            //    var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //    var user = await _userManager.FindByEmailAsync(userId);

            //    var entries = _context.ChangeTracker.Entries()
            //        .Where(q => q.State == EntityState.Modified ||
            //                    q.State == EntityState.Added);

            //    foreach (var entry in entries)
            //    {
            //        if (entry.State == EntityState.Modified)
            //        {
            //            ((EntityBase)entry.Entity).ModifiedDate = DateTime.Now;
            //            ((EntityBase)entry.Entity).ModifiedBy = user?.UserName;
            //        }
            //        else if (entry.State == EntityState.Added)
            //        {
            //            ((EntityBase)entry.Entity).CreatedDate = DateTime.Now;
            //            ((EntityBase)entry.Entity).CreatedBy = user?.UserName;
            //        }
            //    }



            //    var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            //    var changes = await _context.SaveChangesAsync();
            //    return changes > 0;
            //}




            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                         .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;








        }
    }
}
