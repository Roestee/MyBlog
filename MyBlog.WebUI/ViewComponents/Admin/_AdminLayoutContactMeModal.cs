using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutContactMeModal: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
