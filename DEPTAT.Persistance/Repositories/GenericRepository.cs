using DEPTAT.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DeptatDbContext _dbContext;
        private readonly DbSet<T> _db;

        public GenericRepository(DeptatDbContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.Set<T>();
        }
        // private readonly UserManager<ApplicationUser> _userManager;

        //public GenericRepository(DeptatDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task<T> Add(T entity)
        //{
        //    await _dbContext.AddAsync(entity);
        //    return entity;
        //}

        //public async Task Delete(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //}

        //public async Task<bool> Exists(int id)
        //{
        //    var entity = await Get(id);
        //    return entity != null;
        //}

        //public async Task<bool> ItemExists(string name)
        //{
        //    var entity = await _dbContext.Set<T>().Select(name=>name.).FirstOrDefaultAsync().FindAsync(); ;
        //    return entity != null;
        //}

        //public async Task<T> Get(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public async Task<IReadOnlyList<T>> GetAll()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public async Task Update(T entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //}



        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var prop in includes)
                {
                    query = query.Include(prop);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            await _db.AddAsync(entity);
            return entity;
            
        }

        public async Task<T> InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
            return (T)entities;
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _db.AnyAsync(expression);
        }

        public Task Update(T entity)
        {
            _db.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task Delete(T entity)
        {
            var record = await _db.FindAsync(entity);
            _db.Remove(record);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }
    }
}
