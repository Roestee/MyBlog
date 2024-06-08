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

        public async Task<IActionResult> AboutMeList(string? message = null, bool success = false)
        {
            TempData["Message"] = message;
            TempData["MessageType"] = success ? "success" : "error";

            return View(await _aboutMeService.GetAllAsync());
        } 

        public IActionResult AddAboutMe(string? message = null, bool success = false)
        {
            TempData["Message"] = message;
            TempData["MessageType"] = success ? "success" : "error";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAboutMe(AboutMe aboutMe)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _aboutMeService.AddAsync(aboutMe);
            return RedirectToAction(result.Success ? nameof(AboutMeList) : nameof(AddAboutMe), new { message = result.Message, success = result.Success });
        }

        public async Task<IActionResult> UpdateAboutMe(int id, string? message = null, bool success = false)
        {
            TempData["Message"] = message;
            TempData["MessageType"] = success ? "success" : "error";

            return View(await _aboutMeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutMe(AboutMe aboutMe)
        {
            if (!ModelState.IsValid)
                return View(aboutMe);

            var result = await _aboutMeService.UpdateAsync(aboutMe);
            if (result.Success)
                return RedirectToAction(nameof(AboutMeList), new { message = result.Message, success = result.Success });

            return RedirectToAction(nameof(UpdateAboutMe), new { id = aboutMe.Id, message = result.Message, success = result.Success });
        }

        public async Task<IActionResult> DeleteAboutMe(int id)
        {
            var result = await _aboutMeService.DeleteAsync(id);
            return RedirectToAction(nameof(AboutMeList), new { message = result.Message, success = result.Success });
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
