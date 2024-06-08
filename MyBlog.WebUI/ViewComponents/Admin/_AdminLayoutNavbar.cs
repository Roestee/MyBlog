using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutNavbar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
