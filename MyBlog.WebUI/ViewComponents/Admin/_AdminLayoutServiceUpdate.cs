using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutServiceUpdate: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
