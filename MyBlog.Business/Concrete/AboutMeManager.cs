using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class AboutMeManager : IAboutMeService
    {
        private readonly IAboutMeRepository _aboutMeRepository;

        public AboutMeManager(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

        public async Task<IDataResult> AddAsync(AboutMe aboutMe)
        {
            try
            {
                await _aboutMeRepository.AddAsync(aboutMe);
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hakkımda ekleme işlemi başarısız oldu!");
            }

            return new SuccessResult("Hakkımda başarıyla eklendi.");
        }

        public async Task<AboutMe> GetByIdAsync(int id)
        {
            var aboutMe = _aboutMeRepository.GetAllQueryable()
                .Where(x => x.Id == id)
                .Include(x=>x.Skills)
                .Include(x=>x.Educations)
                .Include(x=>x.Experiences);

            return await aboutMe.FirstOrDefaultAsync();
        }

        public async Task<IDataResult> UpdateAsync(AboutMe aboutMe)
        {
            try
            {
                var entity = await _aboutMeRepository.GetByIdAsync(aboutMe.Id);
                entity.Description = aboutMe.Description;
                await _aboutMeRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("Hakkımda güncelleme işlemi başarısız oldu!");
            }

            return new SuccessResult("Hakkımda başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _aboutMeRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hakkımda silinirken sorun oluştu!");
            }

            return new SuccessResult("Hakkımda başarıyla silindi.");
        }
    }
}
