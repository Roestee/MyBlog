using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutHead: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
