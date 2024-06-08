using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutAlert: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
