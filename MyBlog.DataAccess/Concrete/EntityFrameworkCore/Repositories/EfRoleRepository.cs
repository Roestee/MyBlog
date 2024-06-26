using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRoleRepository: EfEntityRepositoryBase<Role, RoesteBlogDbContext>, IRoleRepository
    {
        public EfRoleRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
