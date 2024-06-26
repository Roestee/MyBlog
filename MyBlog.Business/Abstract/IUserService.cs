using System.Linq.Expressions;
using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetAsync(Expression<Func<User, bool>> filter);
        Task<IDataResult> AddAsync(User entity);
        Task<IDataResult> UpdateAsync(User entity);
        Task<IDataResult> DeleteAsync(int id);
        IQueryable<User> GetAllQueryable();
        bool Any(Expression<Func<User, bool>> filter);
    }
}
