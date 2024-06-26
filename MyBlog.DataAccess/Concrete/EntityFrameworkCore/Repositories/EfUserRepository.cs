using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository: EfEntityRepositoryBase<User, RoesteBlogDbContext>, IUserRepository
    {
        public EfUserRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
