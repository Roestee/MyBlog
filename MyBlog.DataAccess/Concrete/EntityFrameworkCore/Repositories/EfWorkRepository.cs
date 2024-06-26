using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfEntityRepositoryBase<Work, RoesteBlogDbContext>, IWorkRepository
    {
        public EfWorkRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
