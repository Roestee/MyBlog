using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutExperienceList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
