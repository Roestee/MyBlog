using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutScripts: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
