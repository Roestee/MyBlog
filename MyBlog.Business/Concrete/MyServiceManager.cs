using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class MyServiceManager : IMyServiceService
    {
        private readonly IMyServiceRepository _myServiceRepository;

        public MyServiceManager(IMyServiceRepository myServiceRepository)
        {
            _myServiceRepository = myServiceRepository;
        }

        public async Task<MyService> GetByIdAsync(int id)
        {
            var myService = _myServiceRepository.GetAllQueryable().
                Where(x=>x.Id == id).
                Include(x => x.Services);
            return await myService.FirstOrDefaultAsync();
        }
    }
}
