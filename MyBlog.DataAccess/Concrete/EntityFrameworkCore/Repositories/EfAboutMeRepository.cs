using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAboutMeRepository: EfEntityRepositoryBase<AboutMe, RoesteBlogDbContext>, IAboutMeRepository
    {
        public EfAboutMeRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
