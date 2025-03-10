using System.Linq.Expressions;

namespace Insurance.Domain.DataContracts
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> CreateRangeAsync(List<TEntity> entities);
        Task<bool> UpdateRangeAsync(List<TEntity> entities);
        bool RemoveRange(List<TEntity> entities);
    }

}
