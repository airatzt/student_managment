using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.EF
{
    public interface IEfRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<IEnumerable<TEntity>> ListAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderBy = null,
            bool isOrderByDescending = false,
            int? skipCount = null,
            int? takeCount = null,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
