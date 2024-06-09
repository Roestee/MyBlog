using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutWorks: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
