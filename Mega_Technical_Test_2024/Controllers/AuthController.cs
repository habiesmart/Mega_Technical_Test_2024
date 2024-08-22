using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_FE_2024.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Mega_Technical_Test_2024.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AuthRequest authRequest;
        private CookieOptions cookie;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            this.authRequest = new AuthRequest();
            this.cookie = new CookieOptions();
            this.cookie.Expires = DateTime.Now.AddMilliseconds(10);
            
        }

        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserName"]))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var user = await this.authRequest.Login(login);
            if (user.UserName != null)
            {
                Response.Cookies.Append("UserName", user.UserName);
                Response.Cookies.Append("Password", user.Password);
                return RedirectToAction("Index", "Home");
            }
            return View(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await this.authRequest.Logout();
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("Password");

            return Redirect(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
