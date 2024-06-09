using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutServices: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
