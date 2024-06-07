using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutFooter: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
