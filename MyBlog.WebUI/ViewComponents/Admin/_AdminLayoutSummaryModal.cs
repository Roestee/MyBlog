using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class _AdminLayoutSummaryModal: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
