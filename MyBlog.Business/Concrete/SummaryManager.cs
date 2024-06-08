using MyBlog.Business.Abstract;
using MyBlog.Core.Utilities.Results;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class SummaryManager : ISummaryService
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryManager(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public async Task<List<Summary>> GetAllAsync()
        {
            return await _summaryRepository.GetAllAsync();
        }

        public async Task<IDataResult> AddAsync(Summary summary)
        {
            try
            {
                await _summaryRepository.AddAsync(summary);
            }
            catch (Exception e)
            {
                return new ErrorResult("Özet ekleme başarız oldu!");
            }

            return new SuccessResult("Özet başarıyla eklendi.");
        }

        public async Task<Summary> GetByIdAsync(int id)
        {
            return await _summaryRepository.GetByIdAsync(id);
        }

        public async Task<IDataResult> UpdateAsync(Summary summary)
        {
            try
            {
                var entity = await GetByIdAsync(summary.Id);
                entity.FullName = summary.FullName;
                entity.JobPosition = summary.JobPosition;
                entity.HomeId = summary.HomeId;

                await _summaryRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                return new ErrorResult("Özet güncelleme başarız oldu!");
            }

            return new SuccessResult("Özet başarıyla güncellendi.");
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            try
            {
                var summary = await GetByIdAsync(id);
                await _summaryRepository.DeleteAsync(summary);
            }
            catch (Exception e)
            {
                return new ErrorResult("Özet silme işlemi başarısız oldu!");
            }

            return new SuccessResult("Özet başarıyla silindi.");
        }
    }
}
