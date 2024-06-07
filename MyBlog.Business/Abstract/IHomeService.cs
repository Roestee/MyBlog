using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IHomeService
    {
        Task<Home> GetFirstHome();
    }
}
