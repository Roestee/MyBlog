using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutHead: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
