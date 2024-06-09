using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class MyWorkManager : IMyWorkService
    {
        private readonly IMyWorkRepository _workRepository;

        public MyWorkManager(IMyWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<MyWork> GetByIdAsync(int id)
        {
            var myWork = _workRepository.GetAllQueryable().
                Where(x => x.Id == id).
                Include(x => x.Works);

            return await myWork.FirstOrDefaultAsync();
        }
    }
}
