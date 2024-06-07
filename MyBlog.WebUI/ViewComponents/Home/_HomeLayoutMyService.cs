using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutMyService : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
