using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_BE_2024.Contexts;
using Mega_Technical_Test_BE_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mega_Technical_Test_BE_2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly ILogger<LogoutController> _logger;
        private MegaTechnicalTestDbContext megaDbContext;

        public LogoutController(ILogger<LogoutController> logger, IServiceProvider service)
        {
            _logger = logger;
            this.megaDbContext = new MegaTechnicalTestDbContext(service.GetRequiredService<DbContextOptions<MegaTechnicalTestDbContext>>());
        }

        [HttpPost(Name = "PostLogout")]
        public JsonResult Post()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("UserName")) || !String.IsNullOrEmpty(Request.Cookies["UserName"]))
            {
                HttpContext.Session.Remove("UserName");
                HttpContext.Session.Remove("Password");
                Response.Cookies.Delete("UserName");
                Response.Cookies.Delete("Password");

                return new JsonResult(true);
            }

            return new JsonResult(false);
        }
    }
}
