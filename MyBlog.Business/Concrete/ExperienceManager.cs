using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceManager(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<IDataResult> AddAsync(Experience experience)
        {
            try
            {
                await _experienceRepository.AddAsync(experience);
            }
            catch (Exception e)
            {
                return new ErrorResult("İş Tecrübesi ekleme işlemi başarısız oldu!");
            }

            return new SuccessResult("İş Tecrübesi başarıyla eklendi.");
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _experienceRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _experienceRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("İş Tecrübesi silme işlemi başarısız oldu!");
            }

            return new SuccessResult("İş Tecrübesi başarıyla silindi.");
        }
    }
}
