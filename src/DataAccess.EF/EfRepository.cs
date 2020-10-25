using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF
{
    public abstract class EfRepository<TEntity, TContext> : IEfRepository<TEntity>
           where TEntity : class, IEntity
           where TContext : DbContext
    {
        private readonly TContext _efContext;
        private DbSet<TEntity> _dbSet;
        protected IQueryable<TEntity> QueryableEntities => _dbSet;

        public EfRepository(TContext context)
        {
            _efContext = context;
            _dbSet = _efContext.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _efContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            await _efContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _efContext.Entry(entity).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderBy = null, bool isOrderByDescending = false, 
            int? skipCount = null, int? takeCount = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.CreateQuery(
                predicate,
                orderBy,
                isOrderByDescending,
                skipCount,
                takeCount,
                includeProperties);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = this.CreateQuery(
                predicate: predicate, null, default, null, null, null);

            return await query.CountAsync();
        }

        private IQueryable<TEntity> CreateQuery(Expression<Func<TEntity, bool>> predicate, 
            Expression<Func<TEntity, object>> orderBy, bool isOrderByDescending,
            int? skipCount, int? takeCount, 
             Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.QueryableEntities;

            query = predicate != null ? query.Where(predicate) : query;

            if (orderBy != null)
            {
                query = isOrderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }

            query = skipCount.HasValue ? query.Skip(skipCount.Value) : query;

            query = takeCount.HasValue ? query.Take(takeCount.Value) : query;

            if (includeProperties != null)
            {
                foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }
    }
}
