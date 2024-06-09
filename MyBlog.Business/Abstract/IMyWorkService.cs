using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IMyWorkService
    {
        Task<MyWork> GetByIdAsync(int id);
    }
}
