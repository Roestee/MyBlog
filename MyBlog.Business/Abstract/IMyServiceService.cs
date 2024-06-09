using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IMyServiceService
    {
        Task<MyService> GetByIdAsync(int id);
    }
}
