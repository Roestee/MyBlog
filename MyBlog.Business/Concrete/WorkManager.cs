using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class WorkManager: IWorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkManager(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<IDataResult> AddAsync(Work work)
        {
            try
            {
                await _workRepository.AddAsync(work);
            }
            catch (Exception e)
            {
                return new ErrorResult("İş ekleme başarısız oldu!");
            }

            return new SuccessResult("İş başarıyla eklendi.");
        }

        public async Task<Work> GetByIdAsync(int id)
        {
            return await _workRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                await _workRepository.DeleteAsync(await GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return new ErrorResult("İş silme başarısız oldu!");
            }

            return new SuccessResult("İş başarıyla silindi.");
        }
    }
}
