using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IEducationService
    {
        Task<IDataResult> AddAsync(Education education);
        Task<Education> GetByIdAsync(int id);
        Task<IDataResult> DeleteAsync(int id);
    }
}
