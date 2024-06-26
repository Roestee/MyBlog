using System.Linq.Expressions;
using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class UserManager: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter)
        {
            return await _userRepository.GetAsync(filter);
        }

        public async Task<IDataResult> AddAsync(User entity)
        {
            try
            {
                await _userRepository.AddAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("Kullancı eklenirken hata oluştu!");
            }

            return new SuccessResult("Kullanıcı başarıyla eklendi.");
        }

        public async Task<IDataResult> UpdateAsync(User entity)
        {
            try
            {
                var user = await _userRepository.GetAsync(x => x.Id == entity.Id);
                user.Email = entity.Email;
                user.PasswordHash = entity.PasswordHash;
                user.PasswordSalt = entity.PasswordSalt;
                user.RoleId = entity.RoleId;

                await _userRepository.UpdateAsync(user);
            }
            catch (Exception e)
            {
                return new ErrorResult("Kullancı güncellenirken hata oluştu!");
            }

            return new SuccessResult("Kullanıcı başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetAsync(x => x.Id == id);
                await _userRepository.DeleteAsync(user);
            }
            catch (Exception e)
            {
                return new ErrorResult("Kullancı silinirken hata oluştu!");
            }

            return new SuccessResult("Kullanıcı başarıyla silindi.");
        }

        public IQueryable<User> GetAllQueryable()
        {
            return _userRepository.GetAllQueryable();
        }
    }
}
