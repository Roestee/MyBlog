using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class SkillManager: ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillManager(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IDataResult> AddAsync(Skill skill)
        {
            try
            {
                await _skillRepository.AddAsync(skill);
            }
            catch (Exception e)
            {
                return new ErrorResult("Yetenek eklenemedi!");
            }

            return new SuccessResult("Yetenek başarıyla eklendi.");
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _skillRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _skillRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("Yetenek silinemedi!");
            }

            return new SuccessResult("Yetenek başarıyla silindi.");
        }
    }
}
