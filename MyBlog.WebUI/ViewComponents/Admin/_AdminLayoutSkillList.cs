using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutSkillList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
