using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfMyServiceRepository : EfEntityRepositoryBase<MyService, MyBlogDbContext>, IMyServiceRepository
    {
        public EfMyServiceRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
