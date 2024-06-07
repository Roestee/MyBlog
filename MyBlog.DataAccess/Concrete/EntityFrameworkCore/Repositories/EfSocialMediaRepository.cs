using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSocialMediaRepository : EfEntityRepositoryBase<SocialMedia, MyBlogDbContext>, ISocialMediaRepository
    {
        public EfSocialMediaRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
