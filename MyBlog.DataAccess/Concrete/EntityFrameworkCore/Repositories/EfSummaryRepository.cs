using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSummaryRepository: EfEntityRepositoryBase<Summary, RoesteBlogDbContext>, ISummaryRepository
    {
        public EfSummaryRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
