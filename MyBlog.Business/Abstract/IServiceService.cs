using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IServiceService
    {
        Task<IDataResult> AddAsync(Service service);
        Task<Service> GetByIdAsync(int id);
        Task<IDataResult> UpdateAsync(Service service);
        Task<IDataResult> DeleteAsync(int id);
    }
}
