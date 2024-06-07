using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfHomeRepository: EfEntityRepositoryBase<Home, MyBlogDbContext>, IHomeRepository
    {
        public EfHomeRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
