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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IHomeService _homeService;
        private readonly ISummaryService _summaryService;
        private readonly IAboutMeService _aboutMeService;
        private readonly ISkillService _skillService;
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly IServiceService _serviceService;
        private readonly IMyServiceService _myServicesService;
        private readonly IFileService _fileService;
        private readonly IWorkService _workService;
        private readonly IMyWorkService _myWorkService;
        private readonly IContactMeService _contactMeService;
        private readonly ISocialMediaService _socialMediaService;

        public AdminController(
            IWebHostEnvironment hostingEnvironment,
            ICompositeViewEngine viewEngine,
            IHomeService homeService,
            ISummaryService summaryService,
            IAboutMeService aboutMeService,
            ISkillService skillService,
            IEducationService educationService,
            IExperienceService experienceService,
            IServiceService serviceService,
            IMyServiceService myServicesService,
            IFileService fileService, 
            IWorkService workService, 
            IMyWorkService myWorkService,
            IContactMeService contactMeService,
            ISocialMediaService socialMediaService)
        {
            _hostingEnvironment = hostingEnvironment;
            _viewEngine = viewEngine;
            _homeService = homeService;
            _summaryService = summaryService;
            _aboutMeService = aboutMeService;
            _skillService = skillService;
            _educationService = educationService;
            _experienceService = experienceService;
            _serviceService = serviceService;
            _myServicesService = myServicesService;
            _fileService = fileService;
            _workService = workService;
            _myWorkService = myWorkService;
            _contactMeService = contactMeService;
            _socialMediaService = socialMediaService;
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
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
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

            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteSummary(int id)
        {
            var result = await _summaryService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSummaryModal/Default", new Summary { HomeId = 1 });

            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
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

        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _skillService.AddAsync(skill);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSkillList/Default", await _aboutMeService.GetByIdAsync(skill.AboutMeId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteSkill(int id, int aboutMeId)
        {
            var result = await _skillService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSkillList/Default", await _aboutMeService.GetByIdAsync(aboutMeId));
            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _educationService.AddAsync(education);
            var data = await RenderPartialViewToString("Components/_AdminLayoutEducationList/Default", await _aboutMeService.GetByIdAsync(education.AboutMeId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteEducation(int id, int aboutMeId)
        {
            var result = await _educationService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutEducationList/Default", await _aboutMeService.GetByIdAsync(aboutMeId));
            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _experienceService.AddAsync(experience);
            var data = await RenderPartialViewToString("Components/_AdminLayoutExperienceList/Default", await _aboutMeService.GetByIdAsync(experience.AboutMeId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteExperience(int id, int aboutMeId)
        {
            var result = await _experienceService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutExperienceList/Default", await _aboutMeService.GetByIdAsync(aboutMeId));
            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        #endregion

        #region My Services

        [HttpPost]
        public async Task<IActionResult> AddService(Service service)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _serviceService.AddAsync(service);
            var data = await RenderPartialViewToString("Components/_AdminLayoutServices/Default", await _myServicesService.GetByIdAsync(service.MyServicesId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _serviceService.UpdateAsync(service);
            var myServices = await _myServicesService.GetByIdAsync(service.MyServicesId);
            var data = await RenderPartialViewToString("Components/_AdminLayoutServices/Default", myServices);

            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteService(int id, int myServiceId)
        {
            var result = await _serviceService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutServices/Default", await _myServicesService.GetByIdAsync(myServiceId));
            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        #endregion

        #region My Works

        public async Task<IActionResult> UploadBgImage(IFormFile file)
        {
            var bgUrl = await _fileService.FileSaveAsync(file, _hostingEnvironment.WebRootPath, "images");

            return Json(new{message = "Resim başarıyla yüklendi.", messageType = "success", bgUrl});
        }

        [HttpPost]
        public async Task<IActionResult> AddWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _workService.AddAsync(work);
            var data = await RenderPartialViewToString("Components/_AdminLayoutWorks/Default", await _myWorkService.GetByIdAsync(work.MyWorksId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteWork(int id, int myWorkId)
        {
            var result = await _workService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutWorks/Default", await _myWorkService.GetByIdAsync(myWorkId));
            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        #endregion

        #region Contact Me

        public async Task<IActionResult> UploadCv(IFormFile file)
        {
            var cvUrl = await _fileService.FileSaveAsync(file, _hostingEnvironment.WebRootPath, "documents");

            return Json(new { message = "CV başarıyla yüklendi.", messageType = "success", cvUrl });
        }

        [HttpPost]
        public async Task<IActionResult> AddContactMe(ContactMe contactMe)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _contactMeService.AddAsync(contactMe);
            var data = await RenderPartialViewToString("Components/_AdminLayoutContactMeUpdate/Default", contactMe);
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactMe(ContactMe contactMe)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _contactMeService.UpdateAsync(contactMe);
            var data = await RenderPartialViewToString("Components/_AdminLayoutContactMeUpdate/Default", contactMe);

            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteContactMe(int id)
        {
            var result = await _contactMeService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutContactMeModal/Default", new ContactMe() { HomeId = 1 });

            return Json(new { message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { isValid = false, errors });
            }

            var result = await _socialMediaService.AddAsync(socialMedia);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSocialMediaList/Default", await _contactMeService.GetByIdAsync(socialMedia.ContactMeId));
            return Json(new { isValid = true, message = result.Message, messageType = result.Success ? "success" : "error", data });
        }

        public async Task<IActionResult> DeleteSocialMedia(int id, int contactMeId)
        {
            var result = await _socialMediaService.DeleteAsync(id);
            var data = await RenderPartialViewToString("Components/_AdminLayoutSocialMediaList/Default", await _contactMeService.GetByIdAsync(contactMeId));
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
