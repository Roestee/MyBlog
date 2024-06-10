using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutSocialMediaList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
