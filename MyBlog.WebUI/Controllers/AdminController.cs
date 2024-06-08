using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyBlog.Business.Abstract;
using MyBlog.Entities;

namespace MyBlog.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IHomeService _homeService;
        private readonly ISummaryService _summaryService;
        private readonly IAboutMeService _aboutMeService;


        public AdminController(
            ICompositeViewEngine viewEngine,
            IHomeService homeService,
            ISummaryService summaryService,
            IAboutMeService aboutMeService )
        {
            _viewEngine = viewEngine;
            _homeService = homeService;
            _summaryService = summaryService;
            _aboutMeService = aboutMeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HomeUpdate()
        {
            return View(await _homeService.GetFirstHome());
        }

        #region Summary

        [HttpPost]
        public async Task<IActionResult> AddSummary(Summary summary)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _summaryService.AddAsync(summary);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSummaryUpdate/Default", summary);
            return Json(new { isValid= true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSummary(Summary summary)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _summaryService.UpdateAsync(summary);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSummaryUpdate/Default", summary);

            return Json( new {isValid = true, message= result.Message, messageType = result.Success ? "success": "error", data });
        }

        public async Task<IActionResult> DeleteSummary(int id)
        {
            var result = await _summaryService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSummaryModal/Default", new Summary { HomeId = 1 });

            return Json(new { message = result.Message, messageType = result.Success? "success": "error", data});
        }

        #endregion

        #region About Me

        [HttpPost]
        public async Task<IActionResult> AddAboutMe(AboutMe aboutMe)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _aboutMeService.AddAsync(aboutMe);
            var data = await RenderPartialViewToString("Components/_AdminLayoutAboutMeUpdate/Default", aboutMe);
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutMe(AboutMe aboutMe)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _aboutMeService.UpdateAsync(aboutMe);
            var data = await RenderPartialViewToString("Components/_AdminLayoutAboutMeUpdate/Default", aboutMe);

            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteAboutMe(int id)
        {
            var result = await _aboutMeService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutAboutMeModal/Default", new AboutMe { HomeId = 1 });

            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        #endregion

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData.Model = ViewData.Model = model;

            await using (var sw = new StringWriter())
            {
                var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

                if (!viewResult.Success)
                {
                    return $"A view with the name {viewName} could not be found";
                }

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
