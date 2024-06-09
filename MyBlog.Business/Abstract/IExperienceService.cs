using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IExperienceService
    {
        Task<IDataResult> AddAsync(Experience experience);
        Task<Experience> GetByIdAsync(int id);
        Task<IDataResult> DeleteAsync(int id);
    }
}
