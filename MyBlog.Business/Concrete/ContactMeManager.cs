using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class ContactMeManager: IContactMeService
    {
        private readonly IContactMeRepository _contactMeRepository;

        public ContactMeManager(IContactMeRepository contactMeRepository)
        {
            _contactMeRepository = contactMeRepository;
        }

        public async Task<IDataResult> AddAsync(ContactMe contactMe)
        {
            try
            {
                await _contactMeRepository.AddAsync(contactMe);
            }
            catch (Exception e)
            {
                return new ErrorResult("İletişim eklenirken hata oluştu!");
            }

            return new SuccessResult("İletişim başarıyla eklendi.");
        }

        public async Task<IDataResult> UpdateAsync(ContactMe contactMe)
        {
            try
            {
                var entity = await GetByIdAsync(contactMe.Id);
                entity.Email = contactMe.Email;
                entity.Phone = contactMe.Phone;
                entity.CVUrl = contactMe.CVUrl;

                await _contactMeRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("İletişim güncellenirken hata oluştu!");
            }

            return new SuccessResult("İletişim başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _contactMeRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("İletişim silinirken hata oluştu!");
            }

            return new SuccessResult("İletişim başarıyla silindi.");
        }

        public async Task<ContactMe> GetByIdAsync(int id)
        {
            var contactMe = _contactMeRepository.GetAllQueryable().
                Where(p => p.Id == id)
                .Include(x => x.SocialMedias);

            return await contactMe.FirstOrDefaultAsync();
        }
    }
}
