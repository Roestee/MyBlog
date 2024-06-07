using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutScript: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
