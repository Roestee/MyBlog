using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class EducationManager : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationManager(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IDataResult> AddAsync(Education education)
        {
            try
            {
                await _educationRepository.AddAsync(education);
            }
            catch (Exception e)
            {
                return new ErrorResult("Eğitim eklenirken hata oluştu!");
            }

            return new SuccessResult("Eğitim başarıyla eklendi.");
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _educationRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _educationRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("Eğitim silinirken hata oluştu!");
            }

            return new SuccessResult("Eğitim başarıyla silindi.");
        }
    }
}
