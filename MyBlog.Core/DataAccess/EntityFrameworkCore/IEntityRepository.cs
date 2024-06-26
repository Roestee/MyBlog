using System.Linq.Expressions;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Core.DataAccess.EntityFrameworkCore
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, CancellationToken c = default);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken c = default);
        Task<T> GetByIdAsync(int id, CancellationToken c = default);
        Task AddAsync(T entity, CancellationToken c = default);
        Task UpdateAsync(T entity, CancellationToken c = default);
        Task DeleteAsync(T entity, CancellationToken c = default);

        IQueryable<T> GetAllQueryable();
        bool Any(Expression<Func<T, bool>> filter);
    }
}
