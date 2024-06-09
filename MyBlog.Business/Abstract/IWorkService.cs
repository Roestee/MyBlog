using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IWorkService
    {
        Task<IDataResult> AddAsync(Work work);
        Task<Work> GetByIdAsync(int id);
        Task<IDataResult> DeleteAsync(int id);
    }
}
