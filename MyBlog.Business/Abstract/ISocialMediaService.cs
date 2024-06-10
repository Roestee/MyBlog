using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface ISocialMediaService
    {
        Task<IDataResult> AddAsync(SocialMedia socialMedia);
        Task<SocialMedia> GetByIdAsync(int id);
        Task<IDataResult> DeleteAsync(int id);
    }
}
