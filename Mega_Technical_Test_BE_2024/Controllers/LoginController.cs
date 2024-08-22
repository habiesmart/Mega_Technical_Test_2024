using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_BE_2024.Contexts;
using Mega_Technical_Test_BE_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mega_Technical_Test_BE_2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private MegaTechnicalTestDbContext megaDbContext;

        public LoginController(ILogger<LoginController> logger, IServiceProvider service)
        {
            _logger = logger;
            this.megaDbContext = new MegaTechnicalTestDbContext(service.GetRequiredService<DbContextOptions<MegaTechnicalTestDbContext>>());
        }

        [HttpPost(Name = "PostLogin")]
        public JsonResult Post([FromBody]LoginViewModel login)
        {
            MsUser? user = this.megaDbContext.MsUsers.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", login.UserName);
                HttpContext.Session.SetString("Password", login.Password);
                Response.Cookies.Append("UserName", user.UserName);
                Response.Cookies.Append("Password", user.Password);

                return new JsonResult(user);
            }

            return new JsonResult(new MsUser());
        }
    }
}
