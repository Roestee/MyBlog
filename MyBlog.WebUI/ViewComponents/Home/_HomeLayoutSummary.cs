using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutSummary: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
