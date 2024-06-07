using Microsoft.AspNetCore.Mvc;
using MyBlog.WebUI.Models;
using System.Diagnostics;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _homeService.GetFirstHome());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
