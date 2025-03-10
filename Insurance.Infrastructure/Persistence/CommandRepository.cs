using Insurance.Domain.DataContracts;

namespace Insurance.Infrastructure.Persistence
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        private readonly InsuranceDbContext _dbContext;

        public CommandRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var addedEntity = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CreateRangeAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public bool RemoveRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            int rowsAffected = _dbContext.SaveChanges();
            return rowsAffected > 0;
        }
    }

}
