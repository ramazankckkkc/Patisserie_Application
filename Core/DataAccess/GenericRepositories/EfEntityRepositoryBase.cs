using Core.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.GenericRepositories
{
    public class EfEntityRepositoryBase<TEntity, TContext, TId> : IAsyncRepository<TEntity>
        where TEntity : BaseEntity<TId>
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now.AddHours(3);
            await _context.AddAsync(entity);
            try
            {
                var sonuc = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now.AddHours(3);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<IQueryable<TEntity>> QueryAsync() => _context.Set<TEntity>();

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now.AddHours(3);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}