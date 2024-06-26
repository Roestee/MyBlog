using System.Linq.Expressions;
using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class RoleManager: IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> filter)
        {
            return await _roleRepository.GetAsync(filter);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> AddAsync(Role entity)
        {
            try
            {
                await _roleRepository.AddAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("Rol eklenirken hata oluştu!");
            }

            return new SuccessResult("Rol başarıyla eklendi.");
        }

        public async Task<IDataResult> UpdateAsync(Role entity)
        {
            try
            {
                var role = await GetByIdAsync(entity.Id);
                role.Name = entity.Name;

                await _roleRepository.UpdateAsync(role);
            }
            catch (Exception e)
            {
                return new ErrorResult("Rol güncellenirken hata oluştu!");
            }

            return new SuccessResult("Rol başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _roleRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("Rol silinirken hata oluştu!");
            }

            return new SuccessResult("Rol başarıyla silindi.");
        }
    }
}
