﻿using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.ViewComponents.Home
{
    public class _HomeLayoutMyWork: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
