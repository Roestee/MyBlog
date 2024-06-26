using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfEducationRepository : EfEntityRepositoryBase<Education, RoesteBlogDbContext>, IEducationRepository
    {
        public EfEducationRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
