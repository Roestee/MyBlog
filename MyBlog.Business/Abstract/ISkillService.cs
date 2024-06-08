using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface ISkillService
    {
        Task<IDataResult> AddAsync(Skill skill);
        Task<Skill> GetByIdAsync(int id);
        Task<IDataResult> DeleteAsync(int id);
    }
}
