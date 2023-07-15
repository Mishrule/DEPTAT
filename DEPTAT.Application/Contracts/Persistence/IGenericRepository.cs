using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task<IReadOnlyList<T>> GetAll(
                Expression<Func<T, bool>> expression = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>
                    orderBy = null, List<string> includes = null);
            
        Task<T> Insert(T entity);
        Task<T> InsertRange(IEnumerable<T> entities);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task Update(T entity);
        Task Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
