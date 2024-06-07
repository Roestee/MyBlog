using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfMyWorkRepository : EfEntityRepositoryBase<MyWork, MyBlogDbContext>, IMyWorkRepository
    {
        public EfMyWorkRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
