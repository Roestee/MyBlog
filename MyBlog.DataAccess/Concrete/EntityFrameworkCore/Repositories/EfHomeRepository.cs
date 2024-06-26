using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfHomeRepository: EfEntityRepositoryBase<Home, RoesteBlogDbContext>, IHomeRepository
    {
        public EfHomeRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
