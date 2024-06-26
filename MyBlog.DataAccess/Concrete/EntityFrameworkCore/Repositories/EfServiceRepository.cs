using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfServiceRepository : EfEntityRepositoryBase<Service, RoesteBlogDbContext>, IServiceRepository
    {
        public EfServiceRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
