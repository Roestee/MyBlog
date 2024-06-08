using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutFooter: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
