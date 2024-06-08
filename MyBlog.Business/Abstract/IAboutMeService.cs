using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IAboutMeService
    {
        Task<IDataResult> AddAsync(AboutMe aboutMe);
        Task<AboutMe> GetByIdAsync(int id);
        Task<IDataResult> UpdateAsync(AboutMe aboutMe);
        Task<IDataResult> DeleteAsync(int id);
    }
}
