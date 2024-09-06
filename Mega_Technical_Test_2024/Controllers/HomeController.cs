using Mega_Technical_Test_2024.Models;
using Mega_Technical_Test_FE_2024.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Mega_Technical_Test_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BPKBRequest bpkbRequest;
        private CookieOptions cookie;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.bpkbRequest = new BPKBRequest();
            this.cookie = new CookieOptions();
            this.cookie.Expires = DateTime.Now.AddMilliseconds(10);
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserName"]))
            {
                List<BPKBViewModel> listbpkb = this.bpkbRequest.ListBPKB().Result;

                return View(listbpkb);
            }

            return Redirect("Auth/Login");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserName"]))
            {
                BPKBViewModel bpkb = new BPKBViewModel();

                bpkb.Location = this.bpkbRequest.GetListStorageLocations().Result.Select(location =>
                new SelectListItem
                {
                    Value = location.LocationId,
                    Text = location.LocationName
                });

                ViewData["action"] = "/Home/Create";

                return View(bpkb);
            }

            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> Create(BPKBViewModel bpkb)
        {
            bpkb.User.UserName = Request.Cookies["UserName"];
            await this.bpkbRequest.Create(bpkb);
            return Redirect(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ReadOrUpdate(string agreementNumber)
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserName"]))
            {
                BPKBViewModel bpkb = this.bpkbRequest.Get(agreementNumber).Result;

                bpkb.Location = this.bpkbRequest.GetListStorageLocations().Result.Select(location =>
                new SelectListItem
                {
                    Value = location.LocationId,
                    Text = location.LocationName
                });

                ViewData["action"] = "/Home/Update";

                return View(bpkb);
            }

            return Redirect(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BPKBViewModel bpkb)
        {
            bpkb.User.UserName = Request.Cookies["UserName"];
            await this.bpkbRequest.Update(bpkb);
            return Redirect(nameof(Index));
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(BPKBViewModel bpkb)
        {
            bpkb.User.UserName = Request.Cookies["UserName"];
            await this.bpkbRequest.Delete(bpkb);
            return Redirect(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
