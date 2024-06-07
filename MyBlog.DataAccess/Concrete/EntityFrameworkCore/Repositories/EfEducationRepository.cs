using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfEducationRepository : EfEntityRepositoryBase<Education, MyBlogDbContext>, IEducationRepository
    {
        public EfEducationRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
