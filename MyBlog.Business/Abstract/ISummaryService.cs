using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface ISummaryService
    {
        Task<List<Summary>> GetAllAsync();
        Task<IDataResult> AddAsync(Summary summary);
        Task<Summary> GetByIdAsync(int id);
        Task<IDataResult> UpdateAsync(Summary summary);
        Task<IDataResult> DeleteAsync(int id);
    }
}
