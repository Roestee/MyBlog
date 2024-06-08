using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class HomeManager : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeManager(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<Home> GetFirstHome()
        {
            var home = _homeRepository.GetAllQueryable()
                .Include(x => x.Summary)
                .Include(x => x.AboutMe)
                .ThenInclude(x => x.Skills)
                .Include(x => x.AboutMe)
                .ThenInclude(x => x.Experiences)
                .Include(x => x.AboutMe)
                .ThenInclude(x => x.Educations)
                .Include(x => x.MyService)
                .ThenInclude(x => x.Services)
                .Include(x => x.MyWork)
                .ThenInclude(x => x.Works)
                .Include(x => x.ContactMe)
                .ThenInclude(x => x.SocialMedias);

            return await home.FirstOrDefaultAsync();
        }

        public async Task<List<Home>> GetAllAsync()
        {
            return await _homeRepository.GetAllAsync();
        }
    }
}
