using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSkillRepository : EfEntityRepositoryBase<Skill, RoesteBlogDbContext>, ISkillRepository
    {
        public EfSkillRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
