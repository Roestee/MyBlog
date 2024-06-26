using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfExperienceRepository : EfEntityRepositoryBase<Experience, RoesteBlogDbContext>, IExperienceRepository
    {
        public EfExperienceRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
