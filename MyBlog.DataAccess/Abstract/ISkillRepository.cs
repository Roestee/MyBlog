using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Abstract
{
    public interface ISkillRepository: IEntityRepository<Skill>
    {
    }
}
