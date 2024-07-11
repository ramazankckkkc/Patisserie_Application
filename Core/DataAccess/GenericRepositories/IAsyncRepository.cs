using System.Linq.Expressions;

namespace Core.DataAccess.GenericRepositories
{
    public interface IAsyncRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity?, bool>> filter);
        Task<IQueryable<TEntity>> QueryAsync();
    }
}