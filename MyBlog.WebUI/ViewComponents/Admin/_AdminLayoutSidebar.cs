using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutSidebar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
