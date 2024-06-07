using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutContactMe: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
