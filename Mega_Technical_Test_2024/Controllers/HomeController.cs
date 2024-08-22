﻿using Mega_Technical_Test_2024.Models;
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
                BPKBViewModel bpkb = new BPKBViewModel();

                bpkb.Location = this.bpkbRequest.GetListStorageLocations().Result.Select(location =>
                new SelectListItem
                {
                    Value = location.LocationId,
                    Text = location.LocationName
                });

                return View(bpkb);
            }
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> Create(BPKBViewModel bpkb)
        {
            bpkb.User.UserName = Request.Cookies["UserName"];
            await this.bpkbRequest.Create(bpkb);
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
