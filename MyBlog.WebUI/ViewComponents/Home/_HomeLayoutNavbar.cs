using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutNavbar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
