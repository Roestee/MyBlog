using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Core.DataAccess.EntityFrameworkCore
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken c = default)
        {
            return await (filter == null
                ? _dbset.ToListAsync(c)
                : _dbset.Where(filter).ToListAsync(c));
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken c = default)
        {
            return await _dbset.FirstOrDefaultAsync(filter, c);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken c = default)
        {
            return await _dbset.FindAsync(id, c);
        }

        public async Task AddAsync(TEntity entity, CancellationToken c = default)
        {
            await _dbset.AddAsync(entity, c);
            await _context.SaveChangesAsync(c);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken c = default)
        {
            await Task.Run(() => _dbset.Update(entity), c);
            await _context.SaveChangesAsync(c);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken c = default)
        {
            await Task.Run(() => _dbset.Remove(entity), c);
            await _context.SaveChangesAsync(c);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbset.AsQueryable();
        }
    }
}
