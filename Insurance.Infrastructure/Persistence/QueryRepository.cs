using Insurance.Domain.DataContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Insurance.Infrastructure.Persistence
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {
        private readonly InsuranceDbContext _dbContext;

        public QueryRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = null)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeFunc != null)
            {
                query = includeFunc(query);
            }
            return await query.FirstOrDefaultAsync();
        }
    }

}
