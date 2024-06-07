using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutAboutMe : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
