using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Abstract
{
    public interface IContactMeService
    {
        Task<IDataResult> AddAsync(ContactMe contactMe);
        Task<IDataResult> UpdateAsync(ContactMe contactMe);
        Task<IDataResult> DeleteAsync(int id);
        Task<ContactMe> GetByIdAsync(int id);
    }
}
