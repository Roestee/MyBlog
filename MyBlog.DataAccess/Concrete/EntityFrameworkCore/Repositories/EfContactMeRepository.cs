using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContactMeRepository: EfEntityRepositoryBase<ContactMe, RoesteBlogDbContext>, IContactMeRepository
    {
        public EfContactMeRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
