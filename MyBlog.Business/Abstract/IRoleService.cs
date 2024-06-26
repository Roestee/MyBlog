using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;
using System.Linq.Expressions;

namespace MyBlog.Business.Abstract
{
    public interface IRoleService
    {
        Task<Role> GetAsync(Expression<Func<Role, bool>> filter);
        Task<Role> GetByIdAsync(int id);
        Task<IDataResult> AddAsync(Role entity);
        Task<IDataResult> UpdateAsync(Role entity);
        Task<IDataResult> DeleteAsync(int id);
    }
}
