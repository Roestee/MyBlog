using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaManager(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<IDataResult> AddAsync(SocialMedia socialMedia)
        {
            try
            {
                await _socialMediaRepository.AddAsync(socialMedia);
            }
            catch (Exception e)
            {
                return new ErrorResult("Sosyal medya ekleme işlemi başarısız oldu!");
            }

            return new SuccessResult("Sosyal medya başarıyla eklendi.");
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _socialMediaRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _socialMediaRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("Sosyal medya silme işlemi başarısız oldu!");
            }

            return new SuccessResult("Sosyal medya başarıyla silindi.");
        }
    }
}
