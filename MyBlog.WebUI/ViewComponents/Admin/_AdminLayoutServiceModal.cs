using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutServiceModal: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
