using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutAboutMeModal: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
