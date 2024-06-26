using MyBlog.Business.Utilities.Security.JWT;
using MyBlog.Core.Utilities.Results;

namespace MyBlog.Business.Abstract
{
    public interface IAuthService
    {
        Task<Token> Login(string email, string password);
        Task<IDataResult> Register(string modelEmail, string modelPassword);
    }
}
