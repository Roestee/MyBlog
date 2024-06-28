using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.WebUI.Models;
using System.Security.Claims;

namespace MyBlog.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var roleClaim = HttpContext.User.FindFirst(ClaimTypes.Role);
            TempData["Authenticated"] = roleClaim != null ? "true": "false";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            var token = await _authService.Login(model.Email, model.Password);
            if (token != null)
            {
                HttpContext.Response.Cookies.Append("jwtToken", token.AccessToken);
                return RedirectToAction("Index", HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Admin" ? "Admin" : "Home");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Register));

            var result = await _authService.Register(model.Email, model.Password);

            TempData["Message"] = result.Message;
            TempData["MessageType"] = result.Success ? "success" : "error";

            return RedirectToAction(result.Success? nameof(Index): nameof(Register));
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("jwtToken");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
