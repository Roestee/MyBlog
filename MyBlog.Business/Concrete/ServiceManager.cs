using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class ServiceManager: IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult> AddAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
            }
            catch (Exception e)
            {
                return new ErrorResult("Hizmet ekleme işlemi başarısız oldu!");
            }

            return new SuccessResult("Hizmet başarıyla eklendi.");
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> UpdateAsync(Service service)
        {
            try
            {
                var entity = await GetByIdAsync(service.Id);
                entity.Description = service.Description;
                entity.Title = service.Title;
                entity.Icon = service.Icon;

                await _serviceRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("Hizmet güncelleme işlemi başarısız oldu!");
            }

            return new SuccessResult("Hizmet başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _serviceRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("Hizmet silme işlemi başarısız oldu!");
            }

            return new SuccessResult("Hizmet başarıyla silindi.");
        }
    }
}
