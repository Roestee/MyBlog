using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutWorkModal: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
