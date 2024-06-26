using MyBlog.Entities;

namespace MyBlog.Business.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateToken(User user, Role role);
    }
}
